using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject activePlayer;
    public PlayerCharacter playerCharacter;
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
        SavePlayerData();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void RunTest()
    {
        // Create a delegate that holds our OnEvent
        EventManager.CallBackMethod myEventDelegate;


        // Store our function in that delegate
        myEventDelegate = OnEvent;

        // Create a few test events

        MyEvent otherEvent = new MyEvent();
        otherEvent.id = "ItemCollected";
        otherEvent.playerKillamount = 27;

        MyEvent thirdEvent = new MyEvent();
        thirdEvent.id = "ItemCollected";
        thirdEvent.playerKillamount = 999;

        // Subscribe to those events - 
        //      In this example, they call the same function, but in others, you might want a new delegate for each listener.

        EventManager.AddListeners("ItemCollected", myEventDelegate);

        // As a test, queue up a few events





    }



    public void SpawnPlayer()
    {
        playerCharacter.doPlayerSetup();

    }

    private void SavePlayerData()
    {
        PlayerData playerData = new PlayerData();

        playerData.health = playerCharacter.health;
        playerData.name = playerCharacter.playerName;

        string json = JsonUtility.ToJson(playerData);


        File.WriteAllText(Application.dataPath + "/Resources/SaveFiles/saveFile.json", json);

        // PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        // Debug.Log(loadedPlayerData.health);
        // Debug.Log(loadedPlayerData.name);
    }

    public void OnEvent(MyEvent myEvent)
    {
        Debug.Log(" THE " + myEvent.id + " EVENT JUST RAN! Other info is: " + myEvent.playerKillamount);
    }

    public class PlayerData
    {
        public string name;
        public float health;
    }

    public class EventManager
    {
        //Create a delegate to respresent the function
        public delegate void CallBackMethod(MyEvent myEvent);
        //Create a dictionary to hold all of the functions to listen to
        private static Dictionary<string, CallBackMethod> listeners = new Dictionary<string, CallBackMethod>();

        //Function to add listeners to the Dictionary
        public static void AddListeners(string myEvent, CallBackMethod listener)
        {
            //check to see if the dictionary already has your event
            if (!listeners.ContainsKey(myEvent))
            {
                //Add it to the Dictionary
                listeners.Add(myEvent, listener);
            }
            else
            {
                //Otherwise, add the CallbackMethod to the listener
                listeners[myEvent] += listener;

            }

        }
        //Removes listners and events from dictionary
        public static void RemoveListeners(string myEvent, CallBackMethod listener)
        {
            //Check for event in dictionary
            if (listeners.ContainsKey(myEvent))
            {
                //Remove listener of specified event
                listeners[myEvent] -= listener;
                //Remove event if no listeners attached
                if (listeners[myEvent] == null)
                {
                    listeners.Remove(myEvent);
                }
            }

        }

        public static void TriggerEvent(MyEvent myEvent)
        {
            //if the event exists then call the delegate
            if (listeners.ContainsKey(myEvent.id))
            {
                listeners[myEvent.id](myEvent);
            }
        }





    }
    public struct MyEvent
    {
        public string id;
        public int playerKillamount;
    }

    public void BattleTransition(string sceneToLoad)
    {
        StartCoroutine(Loader.loaderInstance.LoadYourAsyncScene(sceneToLoad));
    }
}
