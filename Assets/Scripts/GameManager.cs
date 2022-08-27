using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public List<PlayerController> players;

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
            DontDestroyOnLoad(gameManager);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
