using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;

    private void Awake()
    {
        GameManager.gameManager.activePlayer.transform.position = startPos;
    }
}
