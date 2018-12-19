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
    public LineMaker LM;
    private bool timeToSpawn = true, firstEmbark = false; 


    void Start()
    {
        

        GameObject[] pointsA = GameObject.FindGameObjectsWithTag("Waypoint");
        points.AddRange(pointsA);
        StartCoroutine(arraySetup());

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Count == 0)
            return;

       Vector3 tempPos = points[destPoint+1].transform.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tempPos), .75f);


        currentPoint = points[destPoint].transform;



        destPoint = (destPoint + 1) % points.Count;
       
    }


    void Update()
    {
        if (points.Count == 0 && !timeToSpawn)
            return;

        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);

        if (destPoint == points.Count - 1 && timeToSpawn)
        {
            StartCoroutine(arrayAssign());
        }

        if (Vector3.Distance(transform.position, points[destPoint].transform.position) < .1f)
        {
            GotoNextPoint();
        }
    }

    //void OnTriggerEnter(Collider other)
   // {
   //     GotoNextPoint();
   // }

    IEnumerator arrayAssign ()
    {
        //Debug.Log("Yes");
        timeToSpawn = false;
        if (firstEmbark)
        Destroy(GameObject.FindGameObjectWithTag("deleteableWPs"));
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
        yield return new WaitForSeconds(Time.deltaTime);
        LM.nextSegment(); // calls function on line maker for the next segment of roller coaster points
        yield return new WaitForSeconds(.5f);
        timeToSpawn = true;
        firstEmbark = true;
    }

    IEnumerator arraySetup ()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        nextPoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint"));
    }
}
