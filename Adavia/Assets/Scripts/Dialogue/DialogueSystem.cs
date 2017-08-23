using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class DialogueSystem : MonoBehaviour 
{
    [SerializeField]
    private Text npcText;

    [SerializeField]
    private Text npcDialogue;
    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    private Image continueDialogue;


    private StringBuilder stringBuilder;

    private Queue<string> dialogue;

    void Start ()
    {
        dialogueBox.SetActive(false);
        dialogue = new Queue<string>();
        stringBuilder = new StringBuilder();
	}

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DisplayNextDialogue();
        }
    }

    public void Interact(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        npcText.text = dialogue.npcName;
        
        this.dialogue.Clear();

        foreach (var word in dialogue.dialogue)
        {
            this.dialogue.Enqueue(word);
        }
    }

    public void DisplayNextDialogue()
    {
        continueDialogue.enabled = true;

        if (dialogue.Count <= 0)
        {
            EndDialogue();
            return;
        }
        if (dialogue.Count == 1)
        {
            continueDialogue.enabled = false;
        }
        
        string currentDialogue = dialogue.Dequeue();

        StopAllCoroutines();
        StartCoroutine(DisplayDialogue(currentDialogue));
    }

    private IEnumerator DisplayDialogue(string dialogue)
    {
        npcDialogue.text = "";
        foreach (var letter in dialogue.ToCharArray())
        {
            npcDialogue.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
