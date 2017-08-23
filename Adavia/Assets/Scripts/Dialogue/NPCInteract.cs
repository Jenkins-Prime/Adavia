using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private NPCDialogue npcDialogue;

    private void Awake()
    {
        npcDialogue = GetComponent<NPCDialogue>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.CompareTag("Player") && Input.GetButtonDown("Jump"))
        {
            npcDialogue.Interact();
        }
    }
}
