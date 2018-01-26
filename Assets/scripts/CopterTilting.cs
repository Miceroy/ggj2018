using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterTilting : MonoBehaviour {
    public float rotateSpeed = 180;
    public float maxAngle = 20;
    public Transform tr;
    float vert = 0;
    float horiz = 0;
    float curHor = 0;
    float curVert = 0;
    

	// Use this for initialization
	void Start () {
    }

    public void updateTilt(float vertical, float horizontal)
    {
        horiz = horizontal;
        vert = vertical;
    }

    // Update is called once per frame
    void Update () {
        if (Mathf.Abs(horiz) > 0.01)
        {
            curHor -= rotateSpeed * horiz * Time.deltaTime;
        }
        else
        {
            if (curHor > 0.1)
            {
                curHor -= rotateSpeed * Time.deltaTime;
            }
            else if (curHor < -0.1)
            {
                curHor += rotateSpeed * Time.deltaTime;
            }
        }

        if (Mathf.Abs(vert) > 0.01)
        {
            curVert += rotateSpeed * vert * Time.deltaTime;
        }
        else
        {
            if (curVert >= rotateSpeed * Time.deltaTime)
            {
                curVert -= rotateSpeed * Time.deltaTime;
            }
            else if (curVert <= -rotateSpeed * Time.deltaTime)
            {
                curVert += rotateSpeed * Time.deltaTime;
            }
        }

        curHor = Mathf.Clamp(curHor, -maxAngle, maxAngle);
        curVert = Mathf.Clamp(curVert, -maxAngle, maxAngle);
        // rotate x = eteenpäin/taaksepäin
        // rotate z = vasen/oikea
        tr.eulerAngles = new Vector3(curVert, 0, curHor);
     //   Debug.Log("tr.eulerAngles=" + tr.eulerAngles.ToString());
    }
}
