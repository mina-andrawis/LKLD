using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// passed into the dialogue manager whenever we want to start a new dialogue
// hosts all info we need for a single dialogue
// must be marked as serializable in order to show up in the inspector to edit

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] sentences;
    
}
