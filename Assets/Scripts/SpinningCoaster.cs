using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCoaster : MonoBehaviour {

    public bool spin;
    public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!spin)
            {
                spin = true;
            } else
            {
                spin = false;
            }
        }

        if (spin)
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }
	}
}
