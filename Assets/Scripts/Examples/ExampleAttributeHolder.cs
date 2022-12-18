using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttributeHolder : MonoBehaviour
{
    // Show this float in the Inspector as a slider between 0 and 10
    [MyHealth(0f, 100f)]
    public float playerHealth = 0f;
}
