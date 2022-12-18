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
    public Text killCounter;

    public Slider healthBar;

    //Setup Delegate
    public delegate void DoPlayerSetup();
    //Assign Delegate a varible
    public DoPlayerSetup doPlayerSetup;


    public string playerName;
    public int mana;
    public int gold;
    public float health;
    public int maxHealth;



    public void Awake()
    {

        //Assign Functions to my Delegate
        doPlayerSetup += GetDialogueObjects;
        doPlayerSetup += GetPlayerController;
        doPlayerSetup += GetPlayerRB;
        doPlayerSetup += GetHealthBar;
        doPlayerSetup += GetHealth;
    }

    // Start is called before the first frame update
    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void PlayerController_OnHeal(float f)
    {
        playerController.health += f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDialogueObjects()
    {
        DialogueManager.dialogueManager.nameText = nameText;
        DialogueManager.dialogueManager.dialogueText = dialogueText;
        DialogueManager.dialogueManager.animator = animator;
        DialogueManager.dialogueManager.textSound = textSound;
        DialogueManager.dialogueManager.killCounter = killCounter;
    }
    public void GetPlayerRB()
    {
        playerController.rb = GetComponent<Rigidbody2D>();
    }
    public void GetPlayerController()
    {
        playerController = PlayerController.playerController;
        playerController.OnHeal += PlayerController_OnHeal;
    }

    public void GetHealthBar()
    {

        PlayerController.playerController.healthBar = healthBar;
    }

    public void GetHealth()
    {
        PlayerController.playerController.maxHealth = maxHealth;
        PlayerController.playerController.health = health;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}
