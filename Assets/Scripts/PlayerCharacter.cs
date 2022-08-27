using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public PlayerController playerController;
    // Start is called before the first frame update
    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
