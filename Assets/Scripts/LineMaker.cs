using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour {

    public List<GameObject> linePoints = new List<GameObject>();
    Shader shaderLR; //shader for prettier lines



    // Use this for initialization
    void Start () {
        shaderLR = Shader.Find("UI/Default"); //assigns the shader to a default one 
        StartCoroutine(startList());
    }
	
	// Update is called once per frame
	void Update () {
        
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
                    LineRenderer lr = linePoints[i].AddComponent<LineRenderer>();
                    lr.positionCount = 2; //gives it two points
                    lr.SetPosition(0, linePoints[i].transform.position); //assigns the first point to itself
                    lr.SetPosition(1, linePoints[i - 1].transform.position); //assigns the second point to the previous point
                    lr.colorGradient.mode = GradientMode.Fixed; //one colour for the lines
                    lr.material.color = Random.ColorHSV(.5f, 1, .5f, 1, .5f, 1, 1, 1); //assigns a random colour
                    lr.material.shader = shaderLR; //better looking shader
                    lr.endWidth = .5f; //assign an initial width to the lines
                    lr.startWidth = .5f;
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
