using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyscraperController : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
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
                cop.addCollisionVelocity(ve.normalized * 50.0f);
            }
        }
    }
}
