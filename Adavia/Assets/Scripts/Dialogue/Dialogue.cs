using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;
    [TextArea(0, 20)]
    public List<string> dialogue;
}
