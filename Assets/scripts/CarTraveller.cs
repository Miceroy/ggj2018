﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarTraveller : MonoBehaviour {
    public float travelSpeed = 1.0f;
    public Transform [] waypoints;
    int nextIndex = 0;
    Transform tr;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        tr.position = waypoints[0].position;
        ++nextIndex;
	}

    // Update is called once per frame
    void Update()
    {

        float distToDest = (waypoints[nextIndex].position - tr.position).magnitude;
        if (distToDest < (travelSpeed * Time.deltaTime))
        {
            tr.position = waypoints[nextIndex].position;
            ++nextIndex;
        }
        else
        {
            Vector3 v = (waypoints[nextIndex].position - tr.position).normalized;
            Quaternion q = Quaternion.FromToRotation(transform.right, v);
            tr.rotation = q * transform.rotation;
        }

        if (nextIndex >= waypoints.Length)
        {
            nextIndex = 0;
        }

        Vector3 delta = travelSpeed * Time.deltaTime * (waypoints[nextIndex].position - tr.position).normalized;
        tr.position += delta;
    }
}
