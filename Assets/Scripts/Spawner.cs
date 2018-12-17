using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float wpNum, gapSize;
    public GameObject waypoint;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < wpNum; i++)
        {
            GameObject Clone = Instantiate(waypoint, new Vector3(i * gapSize, 0, 0), Quaternion.identity);
            Clone.name = "Waypoint " + i;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
