using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject waypointsRoot;
    public GameObject[] prefabs;

    GameObject getRandomPrefab()
    {
        int index = Random.Range(0, prefabs.Length - 1);
        return prefabs[index];
    }
    // Use this for initialization
    void Start()
    {
        int numWPs = 0;
        while (true)
        {
            Transform ap = waypointsRoot.transform.Find("WP (" + numWPs + ")");
            if (ap == null) break;

            GameObject obj = (GameObject)Instantiate(getRandomPrefab(), ap.position, ap.rotation) as GameObject;
            obj.GetComponent<CarTraveller2>().wpRoot = waypointsRoot;
            obj.GetComponent<CarTraveller2>().startIndex = numWPs;
            ++numWPs;
        }
    }
}
