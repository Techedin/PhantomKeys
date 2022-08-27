using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager dialogueManager;

    private Queue<string> sentences;
    public void Awake()
    {
        if (dialogueManager == null)
        {
            dialogueManager = this;
            DontDestroyOnLoad(dialogueManager);
        }
        else
        {
            DontDestroyOnLoad(dialogueManager);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.name);
    }
}
