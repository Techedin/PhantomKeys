using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Rigidbody2D rb;


    protected float _health;
    protected int _maxHealth;
    public float health { get; set; }
    public int maxHealth { get; set; }

    public abstract void ProcessInputs();
    public abstract void Die();

}
