using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour {
    public RectTransform[] transforms;
    public float minDistance = 90;
    public float maxDistance = 333;
    public float speed = 1000;

    float direction = 0.0f;
    float distance;

    // Use this for initialization
    void Start () {
        distance = maxDistance;
    }

    public void setFocus(bool isFocus)
    {
        if (isFocus)
            direction = -1.0f;
        else
            direction = 1.0f;

    }

	// Update is called once per frame
	void Update () {
        distance += speed * direction * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        transforms[0].localPosition = new Vector3(-distance, distance, 0);
        transforms[1].localPosition = new Vector3(-distance, -distance, 0);
        transforms[2].localPosition = new Vector3(distance, distance, 0);
        transforms[3].localPosition = new Vector3(distance, -distance, 0);
    }
}
