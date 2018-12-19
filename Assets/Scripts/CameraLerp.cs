using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour {

    public Transform target, lookAtTarget;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = lookAtTarget.position - transform.position;

        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos), speed * Time.deltaTime); // simple camera lerp. this script and some methods are disabled as I feel they are better without it
	}
}


