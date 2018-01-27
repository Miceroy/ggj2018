using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullController : MonoBehaviour {
    public GameObject pulu;
    public GameObject particle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
//	void Update () {
//	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("SeagullController::OnTriggerEnter");
        pulu.SetActive(false);
        particle.SetActive(true);
        Invoke("deleteMe", 5.0f);
    }

    void deleteMe()
    {
        Destroy(gameObject);
    }
}
