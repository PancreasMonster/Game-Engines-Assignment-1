using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollercoasterMovement : MonoBehaviour {

    public List<GameObject> points = new List<GameObject>(); // three arrays for the current segment, the next segment and the segment about to be destroyed
    public List<GameObject> deletablePoints = new List<GameObject>();
    public List<GameObject> nextPoints = new List<GameObject>();
    private Transform currentPoint; //for segment builds
    [Range (0,75)]
    public float speed;
    float loopRad, corkRad, eightLoop; //offsets
    public int destPoint = 0, lastRand; // for randomisation
    public GameObject spawner;
    public LineMaker LM;
    private bool timeToSpawn = true, firstEmbark = false;
    Vector3 pos;
    float rad;
    MasterScript MS;


    void Start()
    {

        MS = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>();
        GameObject[] pointsA = GameObject.FindGameObjectsWithTag("Waypoint"); //assigns first segment to array of current points
        points.AddRange(pointsA);
        StartCoroutine(arraySetup());
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Count == 0)
            return;

       Vector3 tempPos = points[destPoint+1].transform.position - transform.position;

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tempPos), .75f); //tested this out and I felt it is better without this, but felt I should leave it here


        currentPoint = points[destPoint].transform; //next target point of coaster



        destPoint = (destPoint + 1) % points.Count; //iterates through points and starts at zero when finished
       
    }


    void FixedUpdate()
    {
        loopRad = MS.loopRadius;
        corkRad = MS.corkscrewRadius;
        eightLoop = MS.figureEightRadius;

        if (points.Count == 0 && timeToSpawn) //for the frame when there is no target
            return;

        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime); //moves to target point

        if(destPoint+1 < points.Count)
        transform.LookAt(points[destPoint+1].transform.position);
        else
        transform.LookAt(points[destPoint].transform.position);

        if (destPoint == points.Count - 1 && timeToSpawn)
        {
            StartCoroutine(arrayAssign());
        }

        if (Vector3.Distance(transform.position, points[destPoint].transform.position) < .1f)
        {
            GotoNextPoint(); //when reaching the target points, calls for the next target
        }
    }

   

    IEnumerator arrayAssign ()
    {
        timeToSpawn = false;
        if (firstEmbark)
        Destroy(GameObject.FindGameObjectWithTag("deleteableWPs")); //destroys spawners
        deletablePoints = points; //sets current segment to deletable points
        foreach (GameObject gObj in deletablePoints)
        {
            gObj.GetComponent<WaypointScripter>().endFade(); //untagged points while calling a fade and destroy function on them
            gObj.transform.tag = ("Fading");
        }
        points.Clear(); //clear points array

        points = nextPoints; //next segment becomes current

        nextPoints.Clear(); // next segment points is emptied
        nextPoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint")); //next segment is added to the next point array
        destPoint = 0;
     
        pos = GameObject.FindGameObjectWithTag("Fading").GetComponentInParent<Spawner>().currentPos;
        
            

        int rand = Random.Range(1, 1); //random range assign a random segment
        if (rand == 0)
        {
            GameObject Clone = Instantiate(spawner, new Vector3(pos.x + 1, pos.y, pos.z), Quaternion.identity);
            Clone.GetComponent<Spawner>().RCM = this.gameObject;
            Clone.GetComponent<Spawner>().ZigZag();
            
        }
        else if (rand == 1)
        {
            
            GameObject Clone = Instantiate(spawner, new Vector3(pos.x, pos.y + loopRad, pos.z), Quaternion.identity);
            Clone.GetComponent<Spawner>().RCM = this.gameObject;
            Clone.GetComponent<Spawner>().Loop();
            
        }  else if (rand == 2)
        { 
            GameObject Clone = Instantiate(spawner, new Vector3(pos.x + 1, pos.y, pos.z - corkRad), Quaternion.identity);
            Clone.GetComponent<Spawner>().RCM = this.gameObject;
            Clone.GetComponent<Spawner>().Corkscrew();
            
        } else
        {
            GameObject Clone = Instantiate(spawner, new Vector3(pos.x + 1, pos.y, pos.z + eightLoop), Quaternion.identity);
            Clone.GetComponent<Spawner>().RCM = this.gameObject;
            Clone.GetComponent<Spawner>().FigureEight();
            
        }
        yield return new WaitForSeconds(Time.deltaTime);
        LM.nextSegment(); // calls function on line maker for the next segment of roller coaster points
        lastRand = rand; // for previous segments placement
        yield return new WaitForSeconds(.5f);
        timeToSpawn = true;
        firstEmbark = true;
    }

    IEnumerator arraySetup ()
    {
        yield return null;
        nextPoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint")); //must wait a frame to assign this to the array of next points
    }

}
