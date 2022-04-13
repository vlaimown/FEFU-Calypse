using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesController : MonoBehaviour
{
    //public Dialogue dialogue;
    public DialogManager dialogueManager;
    public DialogTrigger dialogueTrigger;
    public PlayerController playerController;

    public int startFlag;
    public int coun = 0;
    public GameObject Intro;

    public Intro gameWillStart;

    //[SerializeField] private float gameWillStartIn;

    private void Start()
    {
        startFlag = 0;

        Intro.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (gameWillStart.gameWillStartIn > 0 && gameWillStart.flagIntro == 1)
        {
            gameWillStart.gameWillStartIn -= Time.deltaTime;
        }
        if (gameWillStart.gameWillStartIn <= 0 && gameWillStart.flagIntro == 1)
        {
            if (startFlag == 0)
            {
                Intro.SetActive(false);

                dialogueManager.dialogueWindow.SetActive(true);
                if (dialogueManager.dialogueWindow == true)
                {
                    dialogueTrigger.TriggerDialog();
                }
                startFlag = 1;
            }
        }
    }
}
