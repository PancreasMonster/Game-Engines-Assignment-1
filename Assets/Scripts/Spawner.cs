using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float wpNum, gapSize;
    public GameObject waypoint;

	// Use this for initialization
	void Start () {
        float gapPrev = 0;
		for(int i = 0; i < wpNum; i++)
        {
            float gap = Random.Range(-1.5f, 1.5f);
            gapPrev += gap;
            GameObject Clone = Instantiate(waypoint, new Vector3(gapSize * i, gapPrev, 0), Quaternion.identity);
            Clone.name = "Waypoint";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
