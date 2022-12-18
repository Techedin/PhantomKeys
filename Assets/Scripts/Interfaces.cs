using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces
{

}


public interface IInventoryItem
{
    // All functions that an inventory item implements go here
    // interfaces only hold functions, not variables -- but we can use getters/setters.
    public string displayName { get; set; }
    public string description { get; set; }
    public int itemRarity { get; set; }
    public DamageType DamageType { get; set; }
}

public interface IWeapon
{
    public int weaponDamage { get; set; }
    public int attackSpeed { get; set; }

}





