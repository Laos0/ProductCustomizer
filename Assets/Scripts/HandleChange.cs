using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine;

public class HandleChange : MonoBehaviour {

    public GameObject currentHandle;
    public GameObject handlePrefab;

    public Button changeHandleBtn;

	// Use this for initialization
	void Start () {
        changeHandleBtn.onClick.AddListener(changeHandle);
	}
	
    void changeHandle()
    {
        if (currentHandle)
        {
            Destroy(currentHandle);
        }
        handlePrefab.transform.position = currentHandle.transform.position;
        currentHandle = Instantiate(handlePrefab, handlePrefab.transform.position, Quaternion.identity);
        
    }
}
