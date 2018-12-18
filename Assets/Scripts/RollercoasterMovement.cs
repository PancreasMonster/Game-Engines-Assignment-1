using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollercoasterMovement : MonoBehaviour {

    public List<GameObject> points = new List<GameObject>();
    public List<GameObject> deletablePoints = new List<GameObject>();
    public List<GameObject> nextPoints = new List<GameObject>();
    private Transform currentPoint;
    public float speed;
    public int destPoint = 0;
    public GameObject spawner;
    private bool timeToSpawn = true; 


    void Start()
    {
        

       GameObject[] pointsA = GameObject.FindGameObjectsWithTag("Waypoint");
        points.AddRange(pointsA);
        StartCoroutine(arraySetup());

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
       

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.

        currentPoint = points[destPoint].transform;



        destPoint = (destPoint + 1) % points.Count;
        //destPoint += 1;
    }


    void Update()
    {
        if (points.Count == 0)
            return;

        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);

        if (destPoint == points.Count - 1 && timeToSpawn)
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
        
        deletablePoints = points;
        yield return new WaitForSeconds(Time.deltaTime);
        foreach (GameObject gObj in deletablePoints)
        {
            Destroy(gObj);
        }
        yield return new WaitForSeconds(Time.deltaTime);
        points.Clear();
        yield return new WaitForSeconds(Time.deltaTime);
        points = nextPoints;
        yield return new WaitForSeconds(Time.deltaTime);
        nextPoints.Clear();
        nextPoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint"));
        destPoint = 0;
        yield return new WaitForSeconds(Time.deltaTime);
        Vector3 pos = GameObject.FindGameObjectWithTag("deleteableWPs").GetComponent<Spawner>().currentPos;
        Debug.Log(pos);
        GameObject Clone = Instantiate(spawner, new Vector3(pos.x + 2, pos.y, pos.z), Quaternion.identity);
        Clone.GetComponent<Spawner>().enabled = true;
        yield return new WaitForSeconds(.5f);
        timeToSpawn = true;
    }

    IEnumerator arraySetup ()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        nextPoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint"));
    }
}
