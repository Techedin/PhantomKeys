using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class UnityEditorExample : MonoBehaviour
{

    public void Awake()
    {
        Debug.Log("Awake run in editor");

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start run in editor");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update run in editor");
    }
}

