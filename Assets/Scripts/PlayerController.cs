using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float _speed = 5;
    float _rotateSpeed = 90;
    public float _pickupRange;
    int _stackLimit = 5;

    public GameObject _stack;
    public GameObject _packages;
    public Shader highlightShader;

    private float _topOfStackPosition;
    private Vector3 directionOfMovement;

    // Start is called before the first frame update
    void Start()
    {
        _topOfStackPosition = transform.position.y;


    }

    // Update is called once per frame
    void Update()
    {

        float horrizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Rotate");

        directionOfMovement = new Vector3(horrizontalMovement, 0, verticalMovement) * _speed * Time.deltaTime;
        transform.Translate(directionOfMovement);
        _stack.transform.Rotate(new Vector3(0, rotation * _rotateSpeed * Time.deltaTime, 0));

        GameObject closestPackage = null;
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, _pickupRange);
        foreach (Collider package in objectsInRange)
        {
            closestPackage = getClosestPackage(objectsInRange);
        }
        //closestPackage.GetComponent<Renderer>().material.shader = highlightShader;

        if (Input.GetButtonDown("Jump"))
        {
            if (closestPackage)
            {
                Debug.Log(closestPackage.name + " Is the closest");
                Debug.Log("Adding {0} to stack", closestPackage);
                addClosestPackageToStack(closestPackage);
            }
            else
            {
                dropPackageFromStack();
            }
            
        }


    }


    public GameObject getClosestPackage(Collider[] packages)
    {
        GameObject closestPackage = null;
        float distance = Mathf.Infinity;
        foreach (Collider go in packages)
        {
            if (go.tag == "Package")
            {
                Vector3 diff = go.gameObject.GetComponent<BoxCollider>().ClosestPointOnBounds(transform.position) - transform.position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && curDistance < _pickupRange)
                {
                    closestPackage = go.gameObject;
                    distance = curDistance;
                }
            }
           
        }
        return closestPackage;
    }

    void addClosestPackageToStack(GameObject package)
    {
        if (_stack.transform.childCount < _stackLimit)
        {
            package.transform.parent = _stack.transform;
            float packageHeight = package.GetComponent<MeshRenderer>().bounds.extents.y;
            package.transform.position = new Vector3(transform.position.x,_topOfStackPosition + packageHeight, transform.position.z);
            Destroy(package.GetComponent<Rigidbody>());

            //update topOfStackPosition
            _topOfStackPosition += packageHeight * 2;
            package.tag = "Stacked";
            package.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            //adjustPickupRangeBasedOnWidestPackage();
        }
        else
        {
            stackLimitWarning(package);
        }
        
    }

    void dropPackageFromStack()
    {
        Transform lastPackage = _stack.transform.GetChild(_stack.transform.childCount - 1);
        lastPackage.gameObject.tag = "Package";
        lastPackage.transform.parent = _packages.transform;
        lastPackage.gameObject.AddComponent<Rigidbody>();
        lastPackage.rotation = Quaternion.identity;
        lastPackage.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        if (directionOfMovement == Vector3.zero) { directionOfMovement = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(0f, 1f)); }
        lastPackage.GetComponent<Rigidbody>().AddForce(new Vector3(directionOfMovement.x, 0.1f, directionOfMovement.z).normalized * 400);
        Debug.Log(new Vector3(directionOfMovement.x, 0.5f, directionOfMovement.z));
        float packageHeight = lastPackage.GetComponent<MeshRenderer>().bounds.extents.y;
        _topOfStackPosition -= packageHeight * 2;
        //adjustPickupRangeBasedOnWidestPackage();
    }

    //## doesnt work properly, put on backburner
    //void adjustPickupRangeBasedOnWidestPackage()
    //{
    //    Collider[] stackedObjects = _stack.GetComponentsInChildren<BoxCollider>();
    //    float widestArea = 0;
    //    foreach (Collider stackObject in stackedObjects)
    //    {
    //        Vector3 area = stackObject.ClosestPointOnBounds(stackObject.transform.position);
    //        float distanceToBound = area.magnitude;
    //        if (distanceToBound > widestArea)
    //        {
    //            _pickupRange = distanceToBound;
    //        }
    //    }
    //}

    private void stackLimitWarning(GameObject package)
    {
        //Flash stack red and pop up a warning for player
        Debug.Log("Failed to add {0} to stack: Stack Limit Reached", package);
    }
}
