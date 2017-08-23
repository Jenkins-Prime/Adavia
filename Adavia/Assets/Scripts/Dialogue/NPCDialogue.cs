using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCInteract))]
public class NPCDialogue : MonoBehaviour
{
    [HideInInspector]
    public static NPCDialogue instance;
    //[SerializeField]
    public Dialogue dialogue;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Interact()
    {
        FindObjectOfType<DialogueSystem>().Interact(dialogue);
    }
}
