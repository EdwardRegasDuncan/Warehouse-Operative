using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void obButtonPressed(string levelID)
    {
        SceneManager.LoadScene(levelID);
    }
}
