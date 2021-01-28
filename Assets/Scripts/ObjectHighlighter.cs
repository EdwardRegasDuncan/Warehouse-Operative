using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectHighlighter : MonoBehaviour
{

    public Shader highlightShader;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Package")
        {
            other.GetComponent<Renderer>().material.shader = highlightShader;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
    }
}
