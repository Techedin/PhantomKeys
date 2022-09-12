using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Character
{
    public PlayerController playerController;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public AudioSource textSound;
    // Start is called before the first frame update
    public void Start()
    {
        //Put info into my managers so I can load this between scenes and it still works
        playerController = PlayerController.playerController;
        playerController.rb = GetComponent<Rigidbody2D>();
        DialogueManager.dialogueManager.nameText = nameText;
        DialogueManager.dialogueManager.dialogueText = dialogueText;
        DialogueManager.dialogueManager.animator = animator;
        DialogueManager.dialogueManager.textSound = textSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
