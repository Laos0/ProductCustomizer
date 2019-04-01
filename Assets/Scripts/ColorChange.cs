using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public Button changeColorBtn;
    public GameObject obj;

	// Use this for initialization
	void Start () {
        changeColorBtn.onClick.AddListener(changeColor);
	}
	
    public void changeColor()
    {
        //Debug.Log("Color has been changed");
        if(obj.GetComponent<Renderer>().material.color == Color.black)
        {
            obj.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            obj.GetComponent<Renderer>().material.color = Color.black;
        }
        
    }
}
