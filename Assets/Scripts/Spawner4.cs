using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner4 : MonoBehaviour {

    float wpNum, gapSize;
    float radius, amountOfCorkscrews;
    public GameObject waypoint, spawner;
    public Vector3 pos, currentPos;
    public bool test, first;

    // Use this for initialization
    void OnEnable()
    {
       

        wpNum = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightLenght;
        radius = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightRadius;
        amountOfCorkscrews = GameObject.FindGameObjectWithTag("Master").GetComponent<MasterScript>().figureEightNum;

        for (int i = 0; i < wpNum; i++)
        {
            float scale = 2 / (3 - Mathf.Cos(2 * i));
            pos = transform.TransformPoint(i * 2, radius * Mathf.Sin(i * amountOfCorkscrews * Mathf.PI / wpNum), -radius * Mathf.Cos(i * amountOfCorkscrews * 2 * Mathf.PI / (wpNum/2)) / 2); //makes a figure of eight shape
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
                Clone.transform.tag = ("Waypoint");
            Clone.name = "Waypoint " + i;
            Clone.GetComponent<LineBeat>().AssignBandNum(Mathf.FloorToInt(i * (511 / wpNum)));
            currentPos = Clone.transform.position;
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y + radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true;
            }
        }
    }
}
