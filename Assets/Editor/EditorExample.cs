using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class EditorExample
{

}


[ExecuteInEditMode]

public class MenuItems : MonoBehaviour
{

    // Ctrl+Alt+H for Hello World
    [MenuItem("PlayerDialogue/Create talkable Character %&H", false, 250)]
    private static void CreateDialougeCharacter()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/PlayerDialouge"));
    }
}
