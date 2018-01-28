using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTraveller2 : MonoBehaviour {
    public GameObject wpRoot;
    public int startIndex;
    public float travelSpeed = 1.0f;
    List<Transform> waypoints = new List<Transform>();
    int nextIndex = 0;
    Transform tr;

	// Use this for initialization
	void Start () {
        int i = 0;
        while (true)
        {
            Transform ap = wpRoot.transform.Find("WP ("+i+")");
            if (ap == null) break;
            waypoints.Add(ap);
            ++i;
        }
        Debug.Log("Found " + i + " waypoints");
        
        tr = GetComponent<Transform>();		
		nextIndex = startIndex;
        tr.position = waypoints[nextIndex].position;
	}

    // Update is called once per frame
    void Update()
    {
		float distToDest = (waypoints[nextIndex].position - tr.position).magnitude;
		if (distToDest < (travelSpeed * Time.deltaTime))
		{
				
			tr.position = waypoints[nextIndex].position;
		    ++nextIndex;
            if (nextIndex >= waypoints.Count)
                nextIndex = 0;			
		}
		else
		{
			Vector3 v = (waypoints[nextIndex].position - tr.position).normalized;
			Quaternion q = Quaternion.FromToRotation(transform.right, v);
			tr.rotation = q * transform.rotation;				
		}
			
		Vector3 delta = travelSpeed * Time.deltaTime * (waypoints[nextIndex].position - tr.position).normalized;
        tr.position += delta;
	}
}

