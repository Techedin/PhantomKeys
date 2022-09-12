using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public Collider2D npcBattleTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        //Checks for player
        PlayerCharacter player = collision.GetComponent<PlayerCharacter>();

        if (player != null)
        {
            //Checks if they press the interact button(defined in the Player Controller)

            if (Input.GetKeyDown(player.playerController.interactKey))
            {


            }
        }
    }
}
