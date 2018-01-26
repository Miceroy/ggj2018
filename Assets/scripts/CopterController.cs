using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterController : MonoBehaviour {
    public Vector2 speed = new Vector2(10,10);

    Transform tr;
    // Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log("horizontal=" + horizontal.ToString());
        Debug.Log("vertical=" + vertical.ToString());
        Debug.Log("Time.deltaTime=" + Time.deltaTime.ToString());
        Debug.Log("speed=" + speed.ToString());
        Vector3 delta = new Vector3(horizontal * speed.x * Time.deltaTime, 0, vertical * speed.y * Time.deltaTime);
        Debug.Log("delta=" + delta.ToString());
        tr.Translate(delta);
    }
}
