using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public static Loader loaderInstance;

    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_MyGameObject;


    public int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        if (loaderInstance == null)
        {
            loaderInstance = this;
            DontDestroyOnLoad(loaderInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// 

    //public void LoadBattleSceneRuins()
    //{


    //    m_MyGameObject = GameManager.gameManager.activePlayer;
    //    m_Scene = "SampleBattleScene";
    //    StartCoroutine(LoadYourAsyncScene());


    //}

    public void LoadOverworldRuins()
    {

        m_MyGameObject = GameManager.gameManager.activePlayer;
        m_Scene = "SampleScene";
        StartCoroutine(LoadYourAsyncScene());

    }


    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {

            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(GameManager.gameManager.activePlayer, SceneManager.GetSceneByName(m_Scene));
        GameManager.gameManager.activePlayer.transform.position = GameManager.gameManager.playerSpawn.transform.position;
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

}
