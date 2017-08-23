using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCInteract))]
public class NPCDialogue : MonoBehaviour
{
   
    [SerializeField]
    private Dialogue dialogue;


    public void Interact()
    {
        FindObjectOfType<DialogueSystem>().Interact(dialogue);
    }
}
