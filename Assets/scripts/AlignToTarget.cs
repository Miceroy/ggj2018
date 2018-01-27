using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToTarget : MonoBehaviour {
           
    // Use this for initialization
	void Start () {
		
	}

    void AlignTo(Vector3 v)
    {
        //Vector3 worldOrientation = v;
     //   Vector3 worldOrientation = transform.localToWorldMatrix*orientation.normalized;
      //  Vector3 axis = Vector3.Cross(worldOrientation, v);
       // float angle = Vector3.Angle(worldOrientation, -v);
        //axis = axis == Vector3.zero ? Vector3.forward : axis; //If the two orientations are the same, Vector3.cross returns Vector.zero, which isn't an axis
        //transform.rotation = Quaternion.AngleAxis(angle, axis);
    }

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
