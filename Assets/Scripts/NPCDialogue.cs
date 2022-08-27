using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : DialogueTrigger
{
    public Collider2D npcDialogueTrigger;

    public override void TriggerDialogue()
    {
        DialogueManager.dialogueManager.StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if (Input.GetKeyDown(player.interactKey))
            {
                TriggerDialogue();
            }
        }
    }
}
