using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Brass, Strings, Percussion, Woodwinds, None };
public enum Rarity { Common, Uncommon, Rare, Epic, Legendary };
public class InventoryItem
{
    public string displayName { get; set; }
    public string description { get; set; }
    public int itemRarity { get; set; }
    public DamageType DamageType { get; set; }
}
