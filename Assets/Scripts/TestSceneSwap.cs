using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestSceneSwap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadOverworld()
    {
        Loader.loaderInstance.LoadOverworldRuins();
    }
}
