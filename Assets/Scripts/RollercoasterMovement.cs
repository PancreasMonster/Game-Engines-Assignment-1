using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollercoasterMovement : MonoBehaviour {

    public GameObject[] points;
    private Transform currentPoint;
    public float speed;
    private int destPoint = 0;
    //GameObject 


    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;

        points = GameObject.FindGameObjectsWithTag("Waypoint");

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
       

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.

        currentPoint = points[destPoint].transform;

        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        GotoNextPoint();
    }
}
