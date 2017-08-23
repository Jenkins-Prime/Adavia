using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.CompareTag("Player") && Input.GetButtonDown("Jump"))
        {
            NPCDialogue.instance.Interact();
        }
    }
}
