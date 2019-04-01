using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Purpose of this scrip is to update the item stats view based on the selected items
/// </summary>
public class ItemView : MonoBehaviour {
    public Text nameTxt, dmgTxt, rarityTxt, costTxt;
	// Use this for initialization
	void Start () {
		
	}

    public void displayItemStats(Item item)
    {
        nameTxt.text = item.name;
        dmgTxt.text = "Damage: " + item.damage.ToString();
        rarityTxt.text = "Rarity: " + item.rarity.ToString();
        costTxt.text = "Cost: " + item.cost.ToString();
    }
}
