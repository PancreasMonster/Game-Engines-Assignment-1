using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumData : MonoBehaviour {

    AudioSource aud;
    public float[] audSamples = new float[512];

	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrum();
	}

    void GetSpectrum()
    {
        aud.GetSpectrumData(audSamples, 0, FFTWindow.Blackman); // collects samples from the audio source
    }
}
