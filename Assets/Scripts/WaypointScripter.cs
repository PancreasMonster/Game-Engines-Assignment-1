using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScripter : MonoBehaviour {

    public LineRenderer LR;
    bool fadeIn, fadeOut;
    public float fadeOver;
    float SecondsToFade = 8;
    public Color col;

	// Use this for initialization
	void Start () {
        StartCoroutine(InitialiseLineRenderer()); // a courountine assigns the line renderer as it takes a second to instantiate onto the object
    }

    public void endFade()  // this is called when the coaster passes the segment. fades out the lines then deletes them
    {
        if (LR != null)
        StartCoroutine(FadeOutLR());
        StartCoroutine(DestroyLines()); 
    }

    IEnumerator FadeInLR() // fades the lines into the scene
    {

        float rate = 1.0f / (SecondsToFade/3);

        for (float x = 0.0f; x <= 1.0f; x += Time.deltaTime * rate)
        {
            LR.material.color = new Color(LR.material.color.r, LR.material.color.g, LR.material.color.b, Mathf.Lerp(0, 1, x));
            yield return null;
        }

    }

    IEnumerator FadeOutLR() //fades the lines out of the scene
    {

        float rate = 1.0f / SecondsToFade;

        for (float x = 0.0f; x <= 1.0f; x += Time.deltaTime * rate)
        {
            LR.material.color = new Color(LR.material.color.r, LR.material.color.g, LR.material.color.b, Mathf.Lerp(1, 0, x));
            yield return null;
        }
        
    }

    IEnumerator DestroyLines() //destroys this object
    {
        yield return new WaitForSeconds(SecondsToFade);
        Destroy(this.gameObject);
    }


    IEnumerator InitialiseLineRenderer() //sets LR to the Line Renderer present
    {
        yield return new WaitForSeconds(.5f);
        LR = GetComponent<LineRenderer>();
        if (LR != null)
        StartCoroutine(FadeInLR());
    }
}
