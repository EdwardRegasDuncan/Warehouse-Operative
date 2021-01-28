using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _camera;
    public float cameraSpeed = 10f;
    public Vector3 cameraTargetPosition;
    private bool isActive = false;
    public GameObject movingPanel;
    Vector3 newPanelLocation;

    // Start is called before the first frame update
    void Start()
    {
        cameraTargetPosition = new Vector3(-1, 7, 15);
        newPanelLocation = movingPanel.transform.position + Vector3.down * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, cameraTargetPosition, cameraSpeed * Time.deltaTime);
            movingPanel.transform.position = Vector3.MoveTowards(movingPanel.transform.position, newPanelLocation, 10 * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision");
            cameraTargetPosition = transform.GetChild(0).position;
            Debug.Log($"Active Camera Position: {transform.GetChild(0).position}");
            isActive = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

}
