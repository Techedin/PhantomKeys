using UnityEngine;

public class MyHealthAttribute : PropertyAttribute
{


    public readonly float minHealth;
    public readonly float maxHealth;

    public MyHealthAttribute(float min, float max)
    {
        this.minHealth = min;
        this.maxHealth = max;
    }
}
