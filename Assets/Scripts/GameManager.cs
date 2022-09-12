using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject activePlayer;
    public Transform playerSpawn;

    public static GameManager gameManager;
    //Initalize Singleton
    public void Awake()
    {
        //Singleton Pattern
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer()
    {
        Debug.Log("hit");
        activePlayer = Instantiate(playerPrefab, playerSpawn);

    }

}
