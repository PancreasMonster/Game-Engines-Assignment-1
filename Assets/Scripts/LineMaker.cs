using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour {

    public List<GameObject> linePoints = new List<GameObject>();
    Shader shaderLR; //shader for prettier lines



    // Use this for initialization
    void Start () {
        StartCoroutine(startList());
    }
	
	// Update is called once per frame
	void Update () {
        shaderLR = Shader.Find("UI/Default"); //assigns the shader to a default one 
    }

    IEnumerator startList ()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        linePoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint")); //adds all points of the coaster to an array
        linePoints.AddRange(GameObject.FindGameObjectsWithTag("nextPoint"));
        yield return new WaitForSeconds(Time.deltaTime);
        for (int i = 0; i < linePoints.Count; i ++)
        {
            if (i != 0) { //only the second one on does this
                if (linePoints[i].GetComponent<LineRenderer>() == null) //assures only those points without line renderers get changed
                {
                    linePoints[i].AddComponent<LineRenderer>();
                    linePoints[i].GetComponent<LineRenderer>().positionCount = 2; //gives it two points
                    linePoints[i].GetComponent<LineRenderer>().SetPosition(0, linePoints[i].transform.position); //assigns the first point to itself
                    linePoints[i].GetComponent<LineRenderer>().SetPosition(1, linePoints[i - 1].transform.position); //assigns the second point to the previous point
                    linePoints[i].GetComponent<LineRenderer>().colorGradient.mode = GradientMode.Fixed; //one colour for the lines
                    linePoints[i].GetComponent<LineRenderer>().material.color = Random.ColorHSV(.5f, 1, .5f, 1, .5f, 1, 0, 0); //assigns a random colour
                    linePoints[i].GetComponent<LineRenderer>().material.shader = shaderLR; //better looking shader
                    linePoints[i].GetComponent<LineRenderer>().endWidth = .5f; //assign an initial width to the lines
                    linePoints[i].GetComponent<LineRenderer>().startWidth = .5f;
                }
            }
        }
    }

    public void nextSegment ()
    {
        linePoints.Clear(); //this is called when a new segment is made
        StartCoroutine(startList());
    }
}
