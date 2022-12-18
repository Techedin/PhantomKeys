using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using System.Linq;
public class Inventory : MonoBehaviour
{
    public static Inventory inventoryInstance;

    public int space;
    public bool pickedUp;

    //Initalize Singleton
    public void Awake()
    {
        //Singleton Pattern
        if (inventoryInstance == null)
        {
            inventoryInstance = this;
            DontDestroyOnLoad(inventoryInstance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //Our inventory list
    public List<Item> inventory = new List<Item>();

    public void Start()
    {
        /*
        //Add Items from our InventoryItem class
        inventory.Add(new InventoryItem { displayName = "Tuba", description = "The bigger the better", DamageType = DamageType.Brass, itemRarity = 4 });
        inventory.Add(new InventoryItem { displayName = "Oboe", description = "Will make you a hobo", DamageType = DamageType.Woodwinds, itemRarity = 1 });
        inventory.Add(new InventoryItem { displayName = "Violin", description = "The bow is made from what???", DamageType = DamageType.Strings, itemRarity = 1 });
        inventory.Add(new InventoryItem { displayName = "French Horn", description = "His Western cousin is alot more straight forward", DamageType = DamageType.Brass, itemRarity = 3 });
        inventory.Add(new InventoryItem { displayName = "Bass Drum", description = "Shatter their eardrums", DamageType = DamageType.Percussion, itemRarity = 1 });
        inventory.Add(new InventoryItem { displayName = "Flute", description = "The rats might follow", DamageType = DamageType.Woodwinds, itemRarity = 4 });
        inventory.Add(new InventoryItem { displayName = "Harp", description = "Not very transportable is it?", DamageType = DamageType.Strings, itemRarity = 2 });
           */
        //Find all items in the inventory that have a DamageType of woodwinds
        List<Item> woodwinds = (from item in inventory where item.DamageType == DamageType.Woodwinds select item).ToList();
        foreach (Item item in woodwinds)
        {
            Debug.Log(item.name);
        }
        //Find all items in the inventory that are of Legenedary rating and sort them by name
        List<Item> LegendaryItem = (from item in inventory orderby item.name where item.rarity == Rarity.Legendary select item).ToList();
        foreach (Item item in LegendaryItem)
        {
            Debug.Log(item.name);
        }

    }
    //IEnumerator is the basic way to indicate a coroutine
    //All coroutines require a return
    //yield is basically the pause button
    //yeild return new means that the coroutine will be continued after whatever is called
    //yeild return null stops the coroutine until coroutine is called again.
    public void AddItem(Item item)
    {
        if (inventory.Count >= space)
        {
            Debug.Log("Not enough room.");
            pickedUp = false;
        }
        else
        {
            Debug.Log("Picked Up");
            pickedUp = true;
            inventory.Add(item);
        }
    }

    //Dis is a Lamda Expression. I said "dis" instead of "this" because "dis" is the lazy way of saying "this"
    // public void Activate() => AddItem();

    //You can write this like a normal function and not be lazy(opinion)


}




