using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform trY;
    public Transform trX;
    public Vector2 speed = new Vector2(100, 100);
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        trX.Rotate(-Time.deltaTime * Input.GetAxis("Mouse Y") * speed.y, 0, 0);
        if (trX.localEulerAngles.x > 80 && trX.localEulerAngles.x <= 280)
        {
            trX.Rotate(Time.deltaTime * Input.GetAxis("Mouse Y") * speed.y, 0, 0);
        }

        trY.Rotate(0, Time.deltaTime * Input.GetAxis("Mouse X") * speed.x, 0);
        if (trY.localEulerAngles.y < 270 && trY.localEulerAngles.y > 90)
        {
            trY.Rotate(0, -Time.deltaTime * Input.GetAxis("Mouse X") * speed.x, 0);
        }
    }
}
