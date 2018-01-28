using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterController : MonoBehaviour {
    public Vector2 speed = new Vector2(30,30);
    public Vector3 xSpeed = new Vector3(0, 0, 0);
    Vector3 mySpeed;
    float rotSpeed = 0;
    public float yawSpeed = 90.0f;
    public CopterTilting tilt;

    Transform tr;
    // Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
    }
	
    public void addCollisionVelocity(Vector3 v)
    {
        xSpeed += v;
    }

	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        tilt.updateTilt(vertical, horizontal);
        mySpeed += new Vector3(horizontal * speed.x, 0, vertical * speed.y);
        mySpeed = new Vector3(
            Mathf.Clamp(mySpeed.x, -speed.x, speed.x),
            Mathf.Clamp(mySpeed.y, 0, 0),
            Mathf.Clamp(mySpeed.z, -speed.y, speed.y));

        mySpeed -= 1.0f * Time.deltaTime * mySpeed;
        xSpeed -= 1.0f * Time.deltaTime * xSpeed;
        Vector3 delta = new Vector3(
            (mySpeed.x + xSpeed.x) * Time.deltaTime, 
            (mySpeed.y + xSpeed.y) * Time.deltaTime, 
            (mySpeed.z + xSpeed.z) * Time.deltaTime);

        tr.Translate(delta);

        float yl = Input.GetAxis("YawLeft");
        float yr = Input.GetAxis("YawRight");
        rotSpeed += (yr - yl);
        rotSpeed = Mathf.Clamp(rotSpeed, -1, 1);
        rotSpeed -= 2.0f * Time.deltaTime * rotSpeed;
        tr.Rotate(0, rotSpeed * Time.deltaTime * yawSpeed, 0);
    }
}
