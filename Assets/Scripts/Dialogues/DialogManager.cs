using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Intro introLink;
    [SerializeField] private Image firstCutsceneImage;
    [SerializeField] private Image cutsceneBackgroundImage;

    public int counter;
    public string newName;

    public Image characterIcon;
    public Sprite heroIcon;

    public GameObject dialogueWindow;
    private DialoguesController dialoguesController;

    [SerializeField] private PlayerController Hero;

    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;

    private void Start()
    {
        counter = 0;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        Time.timeScale = 0;

        nameText.text = dialog.name;
        if (dialog.name == "������� �����")
        {
            nameText.color = Color.blue;
            characterIcon.sprite = heroIcon;
        }

        if (dialog.name == "���������")
        {
            nameText.color = Color.yellow;
        }

        sentences.Clear();

        foreach (string sentence in dialog.sentenses) { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        counter++;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
       dialogueText.text = sentence;
    }


    /*IEnumerable TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }*/

    public void EndDialogue()
    {
        dialogueWindow.SetActive(false);
        Time.timeScale = 1;
        counter = 0;

        if (introLink.firstCutscene == 1)
        {
            firstCutsceneImage.gameObject.SetActive(true);
            cutsceneBackgroundImage.gameObject.SetActive(true);
        }

        //dialoguesController.diffFlag = 0;
    }

    private void Update()
    {
        if (Hero.waittime > 0 && introLink.firstCutscene == 1 && counter == 0)
        {
            Hero.waittime -= Time.deltaTime;
            if (Hero.waittime < 0)
            {
                introLink.firstCutscene = 0;
                firstCutsceneImage.gameObject.SetActive(false);
                cutsceneBackgroundImage.gameObject.SetActive(false);
            }
        }
    }
}
