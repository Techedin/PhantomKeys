using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public virtual void TriggerDialogue()
    {
        DialogueManager.dialogueManager.StartDialogue(dialogue);
    }
}
