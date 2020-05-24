using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    float wpNum, gapSize = 2;
    float gapPrev;
    public float radius, amountOfCorkscrews;
    public GameObject waypoint, spawner;
    public Vector3 pos, currentPos;
    public bool test, first;
    int num = 0;

    // Use this for initialization
    void OnEnable () {
        if (first)
            Loop();
        
    }

    public void ZigZag ()
    {
        
        gapPrev = 0;

        wpNum = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().zigZagLenght;

        for (int i = 0; i < wpNum; i++)
        {
           
            float gap = Random.Range(-2.5f, 2.5f); // makes a zig zag shape
            pos = transform.TransformPoint(gapSize * i, gapPrev, 0);
            gapPrev += gap;
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
                Clone.transform.tag = ("Waypoint");
            Clone.name = "Waypoint " + i;
            Clone.GetComponent<LineBeat>().AssignBandNum(num);
            Clone.transform.parent = transform;
            currentPos = Clone.transform.position;
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true;
            }
            if (num == 3)
                num = 0;
            else
                num++;
        }
    }

    public void Loop()
    {
        wpNum = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().loopLenght;
        radius = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().loopRadius;

        for (int i = 0; i < wpNum; i++)
        {


            pos = transform.TransformPoint(radius * Mathf.Sin(i * 2 * Mathf.PI / wpNum), -radius * Mathf.Cos(i * 2 * Mathf.PI / wpNum), i * .1f); //makes a loop shape
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
                Clone.transform.tag = ("Waypoint");
            Clone.name = "Waypoint " + i;
            Clone.GetComponent<LineBeat>().AssignBandNum(num);
            Clone.transform.parent = transform;
            currentPos = Clone.transform.position;
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y + radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true;
            }
            if (num == 3)
                num = 0;
            else
                num++;
        }
    }

    public void Corkscrew()
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
            Clone.GetComponent<LineBeat>().AssignBandNum(num);
            Clone.transform.parent = transform;
            currentPos = Clone.transform.position; // for the segment placing
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y + radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true; //for the beginning 
            }
            if (num == 3)
                num = 0;
            else
                num++;
        }
    }

    public void FigureEight()
    {
        wpNum = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightLenght;
        radius = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightRadius;
        amountOfCorkscrews = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightNum;

        for (int i = 0; i < wpNum; i++)
        {
            float scale = 2 / (3 - Mathf.Cos(2 * i));
            pos = transform.TransformPoint(i * 2, radius * Mathf.Sin(i * amountOfCorkscrews * Mathf.PI / wpNum), -radius * Mathf.Cos(i * amountOfCorkscrews * 2 * Mathf.PI / (wpNum / 2)) / 2); //makes a figure of eight shape
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
                Clone.transform.tag = ("Waypoint");
            Clone.name = "Waypoint " + i;
            Clone.GetComponent<LineBeat>().AssignBandNum(num);
            Clone.transform.parent = transform;
            currentPos = Clone.transform.position;
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y + radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true;
            }
            if (num == 3)
                num = 0;
            else
                num++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Vector3 GetPos(Vector3 pos)
    {
        return currentPos;
    }
}
