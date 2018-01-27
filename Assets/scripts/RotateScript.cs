using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {
    public Vector3 axis = new Vector3(1,0,0);
    public float speed;

	// Use this for initialization
	void Start () {
        axis = axis.normalized;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis*speed*Time.deltaTime);
	}
}
