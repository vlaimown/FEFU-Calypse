using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DialoguesController dialoguesController;
    public DialogManager dialogManager;
    //public ItemPick itemPick;

    public Animator anim;

    public Text firstQuest;
    public Text secondQuest;
    public Text thirdQuest;
    public Image backgroundQuest;
    public Text questText;

    private void FixedUpdate()
    {
        if (dialogManager.PrayFlag == 1)
        {
            firstQuest.gameObject.SetActive(true);
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (dialogManager.dialogueNumber == 4 && dialoguesController.fourthDialogueFlag != 1)
        {
            secondQuest.gameObject.SetActive(true);
            backgroundQuest.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);
        }

        if (dialoguesController.fourthDialogueFlag == 1)
        {
            secondQuest.gameObject.SetActive(false);
            backgroundQuest.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);
            if (dialogManager.dialogueNumber == 5)
            {
                thirdQuest.gameObject.SetActive(true);
                backgroundQuest.gameObject.SetActive(true);
                questText.gameObject.SetActive(true);
                //Destroy(dialoguesController.fourthDialogue.gameObject);
            }
        }

        
        /*if (dialoguesController.fourthDialogueFlag == 1)
        {

        }*/
    }
}
