using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitmasking : MonoBehaviour
{
    public AttackType attackType = AttackType.None;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Damage Type :" + attackType);
            //Bitwise function  for OR
            attackType = AttackType.Brass | AttackType.Strings;
            Debug.Log(attackType);
            //Bitwise function for AND
            attackType = attackType & AttackType.Strings;
            Debug.Log(attackType);
            //Bitwise function for NOT
            attackType = AttackType.Percussion | AttackType.Woodwinds;
            Debug.Log(attackType);
            attackType &= ~AttackType.Woodwinds;
            Debug.Log(attackType);
            attackType |= AttackType.Brass;
            Debug.Log(attackType);
            //Reset value
            attackType = AttackType.Brass | AttackType.Strings;
            Debug.Log(attackType);
            //XOR or thing of it as adding to the bitmask
            attackType ^= AttackType.Percussion; // Toggle fire
            Debug.Log(attackType);
            attackType ^= AttackType.Woodwinds;  // Toggle ice
            Debug.Log(attackType);
        }
    }



}
public enum AttackType
{
    None = 0,
    Brass = 1 << 0, // This starts with the value 1 (00001) and shifts the 1 over 0 bits, so it doesn't change.
    Strings = 1 << 1, // This starts with the value 1 (00001) and shifts 1 over 1 bit (00010).
    Percussion = 1 << 2, // This starts with the value 1 (00001) and shifts 1 over 2 bits (00100).
    Woodwinds = 1 << 3, // This starts with the value 1 (00001) and shifts the 1 over 3 bits (01000).
}
