using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MIKKO TODO:
// - 
// - Aika etsiä tagi...
// - 
//
// "Laitakaupungilla on tulipalo. Poliisi epäilee syyllisen olevan {0}."
// ""

public class AirTraveller : MonoBehaviour {
    public float travelSpeed = 1.0f;
    List<Vector3> waypoints = new List<Vector3>();
    int nextIndex = 0;
    Transform tr;
	Transform ap;
	
	// Use this for initialization
	void Start () {		
	
		foreach (GameObject airpoint in GameObject.FindGameObjectsWithTag("BirdPath"))
		{
			ap = airpoint.GetComponent<Transform>();
			waypoints.Add(ap.position);
		}
		
        tr = GetComponent<Transform>();
		
		nextIndex = Random.Range(0,(waypoints.Count -1));
        tr.position = waypoints[nextIndex];
        
		
	}

    // Update is called once per frame
    void Update()
    {

        float distToDest = (waypoints[nextIndex] - tr.position).magnitude;
        if (distToDest < (travelSpeed * Time.deltaTime))
        {
            tr.position = waypoints[nextIndex];
			nextIndex = Random.Range(0,(waypoints.Count -1));
        }
        else
        {
            Vector3 v = (waypoints[nextIndex] - tr.position).normalized;
            Quaternion q = Quaternion.FromToRotation(transform.right, v);
            tr.rotation = q * transform.rotation;
        }

        //if (nextIndex < waypoints.Length)
        //{
            Vector3 delta = travelSpeed * Time.deltaTime * (waypoints[nextIndex] - tr.position).normalized;
            tr.position += delta;
        /*}
        else
        {
            tr.position = waypoints[0].position;
            nextIndex = 1;
        }*/
    }
}
