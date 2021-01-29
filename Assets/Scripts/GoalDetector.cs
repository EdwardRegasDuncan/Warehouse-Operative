using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetector : MonoBehaviour
{

    public Text messageLabel;
    public List<GameObject> Packages;
    public int _score;
    public int _goal = 4;
    public GameObject winconditionObject;
    public GameObject playercontrollerObject;

    public Material _matt;

    // Start is called before the first frame update
    void Start()
    {
        messageLabel.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        messageLabel.text = $"{_score} / 4 Shapes";
        if(_score == 4)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = _matt;
            winconditionObject.GetComponent<WinCondition>().setWinCondition(true);
            playercontrollerObject.GetComponent<PlayerController>().setPlayerStatus(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collider[] detectedPackages = Physics.OverlapBox(transform.position, transform.GetComponent<BoxCollider>().bounds.extents);
            foreach (var package in detectedPackages)
            {
                if (package.tag == "Stacked"){
                    _score++;
                }
            }
        }
    }
}
