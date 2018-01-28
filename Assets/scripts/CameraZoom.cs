using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public Camera cam;
    public float minFov = 10;
    public float zoomSpeed = 40;
    float curFov;
    float maxFov;

    // Use this for initialization
	void Start () {
        curFov = cam.fieldOfView;
        maxFov = curFov;
    }
	
	// Update is called once per frame
	void Update () {
        //float zoomFactor = (Input.GetKey(KeyCode.F1) ? 1 : 0) - (Input.GetKey(KeyCode.F2) ? 1 : 0);
        float zoomFactor = Input.GetAxis("ZoomOut") - Input.GetAxis("ZoomIn");
        curFov += zoomFactor * Time.deltaTime * zoomSpeed;
        curFov = Mathf.Clamp(curFov, minFov, maxFov);
        cam.fieldOfView = curFov;
    }
}
