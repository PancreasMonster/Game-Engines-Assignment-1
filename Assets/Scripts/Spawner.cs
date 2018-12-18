using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float wpNum, gapSize;
    public GameObject waypoint;
    Vector3 pos;

	// Use this for initialization
	void Start () {
        float gapPrev = 0;
		for(int i = 0; i < wpNum; i++)
        {
            float gap = Random.Range(-1.5f, 1.5f);
            pos = transform.TransformPoint(gapSize * i, gapPrev, 0);
            gapPrev += gap;
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            
            Clone.name = "Waypoint " + i;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
