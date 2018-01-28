using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour {
    public RectTransform[] transforms;
    public float minDistance = 80;
    public float maxDistance = 350;
    
    float direction = 0.0f;
    float interpolant = 1.0f;
    TargetToFilm lastTtf;

    // Use this for initialization
    void Start () {
  //      interpolant = 1.0f;
    }

    public void setFocus(TargetToFilm ttf, bool hasFocus)
    {
        //if (false == ttf.targetActive) return;

        if (hasFocus==true)
        {
            direction = -1.0f / ttf.timeToFilm;
            lastTtf = ttf;
        }
        else
        {
            if(lastTtf) direction = 0.5f / lastTtf.timeToFilm;
        }
    }

    public bool hasShot()
    {
        bool res = interpolant <= 0.0f;
        if (res)
        {
            interpolant = 1.0f;
        }
        return res;
    }

	// Update is called once per frame
	void Update () {
        interpolant += direction * Time.deltaTime;
        interpolant = Mathf.Clamp(interpolant, 0.0f, 1.0f);
        float distance = Mathf.Lerp(minDistance, maxDistance, interpolant);
        transforms[0].localPosition = new Vector3(-distance, distance, 0);
        transforms[1].localPosition = new Vector3(-distance, -distance, 0);
        transforms[2].localPosition = new Vector3(distance, distance, 0);
        transforms[3].localPosition = new Vector3(distance, -distance, 0);
    }
}
