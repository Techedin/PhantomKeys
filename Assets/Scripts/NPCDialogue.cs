using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : DialogueTrigger
{
    //Trigger Collider to check for Player in area
    public Collider2D npcDialogueTrigger;

    public bool isTalking;
    public void Start()
    {
        isTalking = false;
    }

    public void Update()
    {

    }

    public override void TriggerDialogue()
    {
        //Triggers Start dialogue in the Dialogue manager
        DialogueManager.dialogueManager.StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Checks for player
        PlayerCharacter player = collision.GetComponent<PlayerCharacter>();

        if (player != null)
        {
            //Checks if they press the interact button(defined in the Player Controller)
            //ToDo: Make a notifier apper for player to know they can talk with NPC
            if (Input.GetKeyDown(player.playerController.interactKey))
            {
                //Check to see if already talking to NPC
                //TODO: OnTriggerExit change isTalking to false
                if (isTalking == true)
                {
                    DialogueManager.dialogueManager.DisplayNextSentence();
                }
                else
                {
                    //If wasn't talking before start the dialogue
                    TriggerDialogue();
                    isTalking = true;
                }


            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        DialogueManager.dialogueManager.EndDialogue();
        isTalking = false;
    }

}
