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
    List<Transform> waypoints = new List<Transform>();
    int nextIndex = 0;
    Transform tr;
	Transform ap;
	float WaitTime = 0;
	bool isMoving = true;
	
	// Use this for initialization
	void Start () {		
	
		foreach (GameObject airpoint in GameObject.FindGameObjectsWithTag("BirdPath"))
		{
			ap = airpoint.GetComponent<Transform>();
			waypoints.Add(ap);
		}
		foreach (GameObject airpoint in GameObject.FindGameObjectsWithTag("RoofPath"))
		{
			ap = airpoint.GetComponent<Transform>();
			waypoints.Add(ap);
		}
		
        tr = GetComponent<Transform>();
		
		nextIndex = Random.Range(0,(waypoints.Count -1));
        tr.position = waypoints[nextIndex].position;
        
		
	}

    // Update is called once per frame
    void Update()
    {
		if (isMoving)
		{	
			Vector3 delta = travelSpeed * Time.deltaTime * (waypoints[nextIndex].position - tr.position).normalized;
            tr.position += delta;		

			float distToDest = (waypoints[nextIndex].position - tr.position).magnitude;
			if (distToDest < (travelSpeed * Time.deltaTime))
			{
				tr.position = waypoints[nextIndex].position;
				if (waypoints[nextIndex].gameObject.tag == "RoofPath")
				{
					WaitTime = Random.Range(2,6);
					isMoving = false;
					
				}
				else 
				{
					WaitTime = 0;
					
				}
				Invoke("FlyToNextPoint", WaitTime);	
			}
			else
			{
				Vector3 v = (waypoints[nextIndex].position - tr.position).normalized;
				Quaternion q = Quaternion.FromToRotation(transform.right, v);
				tr.rotation = q * transform.rotation;				
			}
			
			
			
		}

        //if (nextIndex < waypoints.Length)
        //{
	}
		
	void FlyToNextPoint()
		{   
			nextIndex = Random.Range(0,(waypoints.Count -1));
			
			isMoving = true;
		}
        /*}
        else
        {
            tr.position = waypoints[0].position;
            nextIndex = 1;
        }*/
}

