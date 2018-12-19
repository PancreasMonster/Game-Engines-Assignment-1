using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour {

    float wpNum, gapSize;
    float radius, amountOfCorkscrews;
    public GameObject waypoint, spawner;
    public Vector3 pos, currentPos;
    public bool test, first; // variables used for testing purposes

    // Use this for initialization
    void OnEnable()
    {
        
        wpNum = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().corkscrewLenght; // this is where the radius, lenght etc. relates to the master script
        radius = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().corkscrewRadius;
        amountOfCorkscrews = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().corkscrewNum; 

        for (int i = 0; i < wpNum; i++)
        {

            pos = transform.TransformPoint(i * 2, radius * Mathf.Sin(i * amountOfCorkscrews * 2 * Mathf.PI / wpNum), radius * Mathf.Cos(i * amountOfCorkscrews * 2 * Mathf.PI / wpNum)); // makes a corkscrew shape
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
            Clone.transform.tag = ("Waypoint"); // if spawned first
            Clone.name = "Waypoint " + i; //names waypoints
            Clone.GetComponent<LineBeat>().AssignBandNum(Mathf.FloorToInt(i * (511 / wpNum))); //assigns a line segment a corresponding band value
            currentPos = Clone.transform.position; // for the segment placing
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y + radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true; //for the beginning 
            }
        }
    }

    public Vector3 GetPos(Vector3 pos)
    {
        return currentPos; //help the rollercoaster to know where to put the next segment
    }
}
