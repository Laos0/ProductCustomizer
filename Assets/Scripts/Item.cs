using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  To hold an object stats
///  Desterialize Json file into item
/// </summary>
[System.Serializable]
public class Item {

    public ItemType itemType;
    public string name;
    public int id;
    public int cost;
    public int durability;
    public int rarity;
    public int damage;
   
    public override string ToString()
    {
        return "Name: " + name
            + ", Id: " + id
            + ", Cost: " + cost
            + ", Durability: " + durability
            + ", Rarity: " + rarity
            + ", Damage: " + damage
            + ", Item Type: " + itemType;
    }
}
