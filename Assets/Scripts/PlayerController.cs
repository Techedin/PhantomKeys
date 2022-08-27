using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode interactKey;
    public float moveSpeed;
    public Vector2 moveDirection;


    // Start is called before the first frame update
    public override void Start()
    {
        //Adds Player Controller to GameManager for referencing purposes
        if (GameManager.gameManager != null)
        {
            //Check to see if this is in the list
            if (GameManager.gameManager.players != null)
            {
                //add to active players list
                GameManager.gameManager.players.Add(this);

            }

            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
    }

    public void FixedUpdate()
    {
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
    }

    public void Move()
    {
        //The rigidbody attach has interpolate on so the movement isn't choppy
        //Allows for free movement in 8 directions
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
