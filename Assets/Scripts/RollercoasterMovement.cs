using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollercoasterMovement : MonoBehaviour {

    public GameObject[] points;
    private GameObject[] deletablePoints;
    private Transform currentPoint;
    public float speed;
    public int destPoint = 0;
    public GameObject spawner;
    private bool timeToSpawn = true;
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
        //destPoint += 1;
    }


    void Update()
    {
        if (points.Length == 0)
            return;

        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);

        if (destPoint == points.Length - 1 && timeToSpawn)
        {
            StartCoroutine(arrayAssign());
        }

    }

    void OnTriggerEnter(Collider other)
    {
        GotoNextPoint();
    }

    IEnumerator arrayAssign ()
    {
        Debug.Log("Yes");
        timeToSpawn = false;
        Instantiate(spawner, transform.position + (transform.right * 150), Quaternion.identity);
        foreach (GameObject gObj in points)
        {
            gObj.transform.tag = ("deleteableWPs");
        }
        yield return new WaitForSeconds(Time.deltaTime);
        destPoint = 0;
        deletablePoints = GameObject.FindGameObjectsWithTag("deleteableWPs");
        points = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject gObj in deletablePoints)
        {
            Destroy(gObj);
        }
        yield return new WaitForSeconds(1);
        timeToSpawn = true;
    }
}
