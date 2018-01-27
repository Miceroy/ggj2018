using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MIKKO TODO:
// - Kameran zoomi smooth
// - Kun tagi kameran fovissa, niin alkaa juosta timeri ja kun aikaa kulunut x määrä, niin tägi näkyy ruudulla (viestii siihen uutiseen)
//    -> Pisteet nousee
// - Kameran rajoitus (x ja y)
// - Rotate skripti: Akseli ja nopeus

public class WaypointTraveller : MonoBehaviour {
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

        if (nextIndex < waypoints.Length)
        {
            Vector3 delta = travelSpeed * Time.deltaTime * (waypoints[nextIndex].position - tr.position).normalized;
            tr.position += delta;
        }
        else
        {
            tr.position = waypoints[0].position;
            nextIndex = 1;
        }
    }
}
