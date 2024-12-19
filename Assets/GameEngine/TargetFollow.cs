using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour {
    public Transform targetToFollow;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (targetToFollow != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetToFollow.transform.position - offset, 8 * Time.deltaTime);
        }
        else
        {
            try { targetToFollow = Plane.instance.transform; offset = (-transform.position + targetToFollow.position);
            }
            catch { }
        }

        }
}
