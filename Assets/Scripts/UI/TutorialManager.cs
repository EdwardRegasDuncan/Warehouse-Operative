using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public Text tutorialMessageLabel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string tutorialStage = name;
            switch (tutorialStage)
            {
                case "TutorialTrigger_1":
                    {
                        setTutorialMessage("Use WASD or the Arrow keys to move");
                        break;
                    }
                case "TutorialTrigger_2":
                    {
                        setTutorialMessage("Press SPACE BAR to pickup shapes, you must bring all shapes you find to the last room");
                        break;
                    }
                case "TutorialTrigger_3":
                    {
                        setTutorialMessage("You can rotate held shapes by using\nQ & E or PgUp & PgDn");
                        break;
                    }
                case "TutorialTrigger_4":
                    {
                        setTutorialMessage("You can stack other shapes on top with SPACE BAR");
                        break;
                    }
                case "TutorialTrigger_5":
                    {
                        setTutorialMessage("You can drop shapes one at a time by pressing SPACE BAR");
                        break;
                    }
                case "TutorialTrigger_6":
                    {
                        setTutorialMessage("Your current rotation matters when picking up a new shapes");
                        break;
                    }
                case "TutorialTrigger_7":
                    {
                        setTutorialMessage("bring all the shapes here to win");
                        break;
                    }
            }
        }
    }

    void setTutorialMessage(string message)
    {
        tutorialMessageLabel.text = message;
    }
}
