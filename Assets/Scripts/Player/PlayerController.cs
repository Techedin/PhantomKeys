using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerController : Controller
{
    public static PlayerController playerController;

    public KeyCode interactKey;
    public KeyCode healButton;
    public float moveSpeed;
    public Vector2 moveDirection;

    public Inventory inventory;

    public Slider healthBar;

    //Here is my events
    public event HealAmount OnHeal;
    public delegate void HealAmount(float f);
    //Here is my unity event which is attached to my EnemyPool SpawnEnemies()
    public UnityEvent unityEvent;

    Camera cam;

    //Private varibles to protect flimsy or unsafe changes
    private int _playerkills;
    public int playerKills
    {
        get
        {
            return _playerkills;
        }
        set
        {
            _playerkills = value;
            DialogueManager.dialogueManager.killCounter.text = "Player Kills: " + playerKills.ToString();
            OnKillCheck();
        }
    }

    public new float health
    {
        //get is called when on the right side of the argument ??? = health
        get
        {
            return _health;
        }
        //set is called on the left side of the function health = ????
        set
        {

            _health = Mathf.Clamp(value, 1, _maxHealth);
            UpdateHealthUI();
            if (_health <= 0) Die();

        }
    }
    public new int maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        _playerkills = 0;
        cam = Camera.main;

        if (playerController == null)
        {
            playerController = this;
            DontDestroyOnLoad(playerController);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    public void Update()
    {
        //Wanna try putting this into a Corutine
        ProcessInputs();
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null)
            {
                Interactable interactable = ray.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.clicked = true;
                }
            }
            else
            {

                Debug.Log("NO Interactable");
            }
        }
        //All active movement needs to go here so we don't move off of frames
        Move();

    }

    public override void ProcessInputs()
    {
        //Works with WASD and Arrow keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //Makes diagonal movement correct with the normalized since it rounds down to 1;
        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(healButton))
        {
            OnHeal?.Invoke(5.0f);
            unityEvent?.Invoke();
        }

    }

    public void Move()
    {
        //The rigidbody attach has interpolate on so the movement isn't choppy
        //Allows for free movement in 8 directions
        if (rb != null)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            Debug.Log("No RB Found");
        }

    }

    public void UpdateHealthUI()
    {
        healthBar.value = health / maxHealth;
    }


    public override void Die()
    {
        Debug.Log("I died oh no");
    }

    public void OnKillCheck()
    {

        if (playerKills == 5)
        {
            Debug.Log("You've been rewarded a Killer badge. Turn these in to get specialty items");
        }
        if (playerKills == 10)
        {
            Debug.Log("You've been rewarded a Slayer badge. Turn these in to get specialty items");
        }
        if (playerKills == 15)
        {
            Debug.Log("You've been rewarded a Hunter badge. Turn these in to get specialty items");
        }
    }

}
