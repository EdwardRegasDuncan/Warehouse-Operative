using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject quitButton;
    public GameObject winMessage;
    public bool winCondition = false;

    void Start()
    {
        quitButton.SetActive(false);
        winMessage.SetActive(false);
    }

    private void Update()
    {
        if (winCondition)
        {
            
        }
    }

    public void onButtonPressed()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void setWinCondition(bool condition)
    {
        quitButton.SetActive(true);
        winMessage.SetActive(true);
    }
}
