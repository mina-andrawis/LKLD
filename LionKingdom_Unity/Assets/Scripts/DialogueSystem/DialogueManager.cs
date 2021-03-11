using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences; //FIFO behavior in order to store sentences

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
}
