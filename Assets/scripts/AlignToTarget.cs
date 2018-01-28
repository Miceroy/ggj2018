using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToTarget : MonoBehaviour {
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Finish"))
        {
            Transform target = GameObject.FindWithTag("Finish").transform;
            transform.LookAt(target, new Vector3(0, -1, 0));
           // Vector3 v = (target.position - transform.position).normalized;
           //  AlignTo(v);
           //Quaternion q = Quaternion.FromToRotation(transform.right, v);
           //transform.localRotation = q * transform.localRotation;
        }
        else
        {
        }
    }
}
