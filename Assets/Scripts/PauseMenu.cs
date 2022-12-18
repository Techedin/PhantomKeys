using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

//Simple Example of a name space
//put it here because I haven't made a duplicate fuction name
//Simple put namespaces are like code folders. you have to call the folder
//then the functions in the folder
namespace PauseFunctions
{
    //To call anything in PauseMenu would be written like PauseFunctions.PauseMenu.LoadSave1();
    //Add an extra layer of security to protect from duplicate functions.
    public class PauseMenu : MonoBehaviour
    {
        public Canvas pauseCanvas;
        // Filenames will be loaded in as a string. 
        string savePath1;
        // The text of the file will be stored in a TextAsset file.
        TextAsset jsonFile1;

        // Filenames will be loaded in as a string. 
        string savePath2;
        // The text of the file will be stored in a TextAsset file.
        TextAsset jsonFile2;

        // Start is called before the first frame update
        void Start()
        {
            pauseCanvas.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseCanvas.isActiveAndEnabled == false)
                {
                    pauseCanvas.enabled = true;
                }
                else
                {
                    pauseCanvas.enabled = false;
                }
            }

        }


        public void LoadSave1()
        {
            //YOU HAVE TO MAKE YOUR OWN RESOURCE FOLDER
            // write our path for our save file
            savePath1 = "SaveFiles/saveFile";
            // This pulls the text from a json save file
            jsonFile1 = Resources.Load<TextAsset>(savePath1);
            GameManager.PlayerData loadedPlayerData = JsonUtility.FromJson<GameManager.PlayerData>(jsonFile1.ToString());
            PlayerController.playerController.health = loadedPlayerData.health;
            Debug.Log(jsonFile1);
        }


        public void LoadSave2()
        {
            //YOU HAVE TO MAKE YOUR OWN RESOURCE FOLDER
            // write our path for our save file
            savePath2 = "SaveFiles/saveFile1";
            // This pulls the text from a json save file
            jsonFile2 = Resources.Load<TextAsset>(savePath2);
            GameManager.PlayerData loadedPlayerData = JsonUtility.FromJson<GameManager.PlayerData>(jsonFile2.ToString());
            PlayerController.playerController.health = loadedPlayerData.health;
            Debug.Log(jsonFile2);
        }

        public void Exit()
        {
            pauseCanvas.enabled = false;
        }
    }
}
