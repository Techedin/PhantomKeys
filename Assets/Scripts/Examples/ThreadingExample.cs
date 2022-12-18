using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure of threading is being used to put this in
using System.Threading;

public class ThreadingExample : MonoBehaviour
{
    public void Start()
    {
        //How you declare a new thread
        Thread t = new Thread(WriteB);
        //Start a new Thread
        t.Start();

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(System.String.Format("A"));
        }


    }
    static void WriteB()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(System.String.Format("B"));

        }
    }

}
