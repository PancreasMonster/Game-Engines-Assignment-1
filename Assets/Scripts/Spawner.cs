using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float wpNum, gapSize;
    float gapPrev;
    int randomSelection = 0;
    public float radius;
    public GameObject waypoint, spawner;
    public Vector3 pos, currentPos;
    public bool test, first;

	// Use this for initialization
	void OnEnable () {
        gapPrev = 0;
        if (first)
        randomSelection = Random.Range(0, 1);
        if (randomSelection == 0)
        {
            for (int i = 0; i < wpNum; i++)
            {

                float gap = Random.Range(-2.5f, 2.5f);
                pos = transform.TransformPoint(gapSize * i, gapPrev, 0);
                gapPrev += gap;
                GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
                if (first)
                    Clone.transform.tag = ("Waypoint");
                Clone.name = "Waypoint " + i;
                currentPos = Clone.transform.position;
                if (first && i == wpNum - 1)
                {
                    GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + gapSize, pos.y, pos.z), Quaternion.identity);
                    Spawner1.GetComponent<Spawner>().enabled = true;
                }
            }
        }
        {
            for (int i = 0; i < wpNum; i++)
            {

                float gap = Random.Range(-2.5f, 2.5f);
                pos = transform.TransformPoint(radius * Mathf.Sin(i * 2 * Mathf.PI / wpNum), radius * Mathf.Cos(i * 2 * Mathf.PI / wpNum), i * .25f);
                gapPrev += gap;
                GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
                if (first)
                    Clone.transform.tag = ("Waypoint");
                Clone.name = "Waypoint " + i;
                currentPos = Clone.transform.position;
                if (first && i == wpNum - 1)
                {
                    GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + gapSize, pos.y, pos.z), Quaternion.identity);
                    Spawner1.GetComponent<Spawner>().enabled = true;
                }
            }
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
