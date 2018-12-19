using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBeat : MonoBehaviour {

    public SpectrumData SD;
    LineRenderer LR;
    float maxScale = 250;
    public int bandNum; 
    bool start = false;

    // Use this for initialization
    void Start()
    {
   
        StartCoroutine(InitialiseLineRenderer());
        SD = GameObject.FindGameObjectWithTag("SpectrumData").GetComponent<SpectrumData>();
       // rand = Random.Range(0, 512);
    }

    // Update is called once per frame
    void Update()
    {
        if (LR != null && start)
        {
            LR.endWidth = .5f + (maxScale * SD.audSamples[bandNum]); //makes it so each line segment beats to its appropiate band number
            LR.startWidth = .5f + (maxScale * SD.audSamples[bandNum]);
        }
    }

    IEnumerator InitialiseLineRenderer()
    {
        yield return new WaitForSeconds(.5f);
        LR = GetComponent<LineRenderer>();
        start = true;
    }

    public void AssignBandNum (int num)
    {
        bandNum = num;
    }
}
