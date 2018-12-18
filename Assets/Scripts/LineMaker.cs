using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour {

    public List<GameObject> linePoints = new List<GameObject>();

    // Use this for initialization
    void Start () {
        StartCoroutine(startList());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator startList ()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        linePoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
        linePoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint"));
        yield return new WaitForSeconds(Time.deltaTime);
        for (int i = 0; i < linePoints.Count; i ++)
        {
            if (i != 0) {
                linePoints[i].AddComponent<LineRenderer>();
                linePoints[i].GetComponent<LineRenderer>().positionCount = 2;
                linePoints[i].GetComponent<LineRenderer>().SetPosition(0, linePoints[i].transform.position);
                linePoints[i].GetComponent<LineRenderer>().SetPosition(1, linePoints[i-1].transform.position);

            }
        }
    }
}
