using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject playerController;
    public bool gamePaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gamePaused)
        {
            pauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && gamePaused)
        {
            continueGame();
        }
    }

    void pauseGame()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        playerController.GetComponent<PlayerController>().setPlayerStatus(false);
    }

    void continueGame()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        playerController.GetComponent<PlayerController>().setPlayerStatus(true);
    }

    public void onContinueButtonPressed()
    {
        continueGame();
    }

    public void onQuitToDesktopPressed()
    {
        Application.Quit();
    }

}
