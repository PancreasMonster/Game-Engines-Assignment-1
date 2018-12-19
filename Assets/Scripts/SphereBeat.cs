using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBeat : MonoBehaviour {

    public SpectrumData SD;
    [Range(0, 100)]
    public float maxScale;
    public float test;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(1 + (maxScale * SD.audSamples[5]), 1 + (maxScale * SD.audSamples[5]), 1 + (maxScale * SD.audSamples[5])); //makes it so the sphere beats to its appropiate band number
        test = maxScale * SD.audSamples[5];

    }
}
