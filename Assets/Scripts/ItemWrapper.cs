using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemWrapper{

    // Purpose is for json utility to be able to 
    // to desterialized an array of json items
    public List<Item> items;
}
