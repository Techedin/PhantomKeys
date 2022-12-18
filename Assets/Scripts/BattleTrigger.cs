using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BattleTrigger : MonoBehaviour
{
    public Collider2D npcBattleTrigger;
    public int killTotalValue;
    public string battleScene;
    // Start is called before the first frame update
    public void Start()
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
                GameManager.gameManager.BattleTransition(battleScene);
                // PlayerController.playerController.playerKills += killTotalValue;
                // gameObject.SetActive(false);

            }
        }
    }


}
