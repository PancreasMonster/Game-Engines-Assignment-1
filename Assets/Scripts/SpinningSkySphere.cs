using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSkySphere : MonoBehaviour {

    public bool spin = false;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!spin)
            {
                spin = true;
            }
            else
            {
                spin = false;
            }
        }

        if (spin)
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        } else
        {
            transform.Rotate(Vector3.left, speed * Time.deltaTime);
        }
    }
}
