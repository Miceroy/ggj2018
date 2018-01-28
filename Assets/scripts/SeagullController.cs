using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullController : MonoBehaviour {
    public GameObject pulu;
    public GameObject particle;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
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
                Vector3 ve = cop.gameObject.transform.position - transform.position;
                ve.y = 0;
                cop.addCollisionVelocity(ve.normalized * 30.0f);
            }
        }
    }

    void deleteMe()
    {
        Destroy(gameObject);
    }
}
