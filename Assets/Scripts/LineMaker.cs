using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour {

    public List<GameObject> linePoints = new List<GameObject>();
    Shader shaderLR;



    // Use this for initialization
    void Start () {
        StartCoroutine(startList());
    }
	
	// Update is called once per frame
	void Update () {
        shaderLR = Shader.Find("UI/Default");
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
                if (linePoints[i].GetComponent<LineRenderer>() == null)
                {
                    linePoints[i].AddComponent<LineRenderer>();
                    linePoints[i].GetComponent<LineRenderer>().positionCount = 2;
                    linePoints[i].GetComponent<LineRenderer>().SetPosition(0, linePoints[i].transform.position);
                    linePoints[i].GetComponent<LineRenderer>().SetPosition(1, linePoints[i - 1].transform.position);
                    linePoints[i].GetComponent<LineRenderer>().colorGradient.mode = GradientMode.Fixed;
                    linePoints[i].GetComponent<LineRenderer>().material.color = Random.ColorHSV(.5f, 1, .5f, 1, .5f, 1, 0, 0);
                    linePoints[i].GetComponent<LineRenderer>().material.shader = shaderLR;
                    linePoints[i].GetComponent<LineRenderer>().endWidth = .5f;
                    linePoints[i].GetComponent<LineRenderer>().startWidth = .5f;
                }
            }
        }
    }

    public void nextSegment ()
    {
        linePoints.Clear();
        StartCoroutine(startList());
    }
}
