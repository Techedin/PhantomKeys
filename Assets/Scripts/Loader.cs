using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public static Loader loaderInstance;

    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;
    public Scene sceneToLoad;
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



    public void LoadBattleSceneRuins()
    {
        m_MyGameObject = GameManager.gameManager.activePlayer;
        StartCoroutine(LoadYourAsyncScene("SampleBattleScene"));
    }

    public void LoadOverworldRuins()
    {
        m_MyGameObject = GameManager.gameManager.activePlayer;
        StartCoroutine(LoadYourAsyncScene("SampleScene"));
        //StartCoroutine(LoadYourAsyncScene(SceneManager.GetSceneByName("SampleScene")));
    }


    public IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex, but I'm going to stick with string for right now

        Scene sceneToUnload = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            //Whatever needs to be done before scene loads
            GameManager.gameManager.SpawnPlayer();
            yield return null;
        }
        //everything after scene loads


    }


}
