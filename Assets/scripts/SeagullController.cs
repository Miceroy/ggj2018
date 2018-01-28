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
    //    Debug.Log("SeagullController::OnTriggerEnter");
        pulu.SetActive(false);
        particle.SetActive(true);
        Invoke("deleteMe", 5.0f);
        if (
            other.gameObject.transform.parent &&
            other.gameObject.transform.parent.parent &&
            other.gameObject.transform.parent.parent.parent &&
            other.gameObject.transform.parent.parent.parent.parent )
        {
            CopterController cop = other.gameObject.transform.parent.parent.parent.parent.GetComponent<CopterController>();
            if (cop)
            {
                //  Debug.Log("OnTriggerEnter: "+ (cop.gameObject.transform.position - other.transform.position).ToString());
                //Debug.Log("OnTriggerEnter: " + cop.gameObject.name/*transform.position.ToString()*/ + " ," + other.gameObject.name/*.transform.position.ToString()*/);
                Vector3 ve = cop.gameObject.transform.position - transform.position;
                ve.y = 0;
                cop.addCollisionVelocity(ve.normalized * 30.0f);
                // cop.addCollisionVelocity(new Vector3(20,0,0));
            }
        }
    }

    void deleteMe()
    {
        Destroy(gameObject);
    }
}
