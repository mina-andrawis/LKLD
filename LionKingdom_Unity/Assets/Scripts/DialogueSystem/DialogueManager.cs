using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       //to retirieve UI elements from untiy

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences; //FIFO behavior in order to store sentences

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);       //set to true since a new dialog is occurring

        nameText.text = dialogue.name;

        sentences.Clear();      //clear previous sentences in queue

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)       //no more sentences to show
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);       //set to false since a dialogue has ended

    }


}