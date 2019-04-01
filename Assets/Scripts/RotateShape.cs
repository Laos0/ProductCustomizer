using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShape : MonoBehaviour {
    int speed;
    // Update is called once per frame
    void Start()
    {
        speed = 30;
    }
    void Update () {
        this.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        // The bottom code added in will rotate the cube in an angle
        //this.transform.Rotate(Vector3.right * Time.deltaTime * 5);
	}
}
