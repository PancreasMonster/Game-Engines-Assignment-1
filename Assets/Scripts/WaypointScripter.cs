using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScripter : MonoBehaviour {

    public LineRenderer LR;
    bool fadeIn, fadeOut;
    public float fadeOver;
    public float SecondsToFade = 4;
    public Color col;

	// Use this for initialization
	void Start () {
        StartCoroutine(InitialiseLineRenderer());
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void endFade()
    {
        StartCoroutine(FadeOutLR());
        StartCoroutine(DestroyLines());
    }

    IEnumerator FadeInLR()
    {

        float rate = 1.0f / SecondsToFade;

        for (float x = 0.0f; x <= 1.0f; x += Time.deltaTime * rate)
        {
            LR.material.color = new Color(LR.material.color.r, LR.material.color.g, LR.material.color.b, Mathf.Lerp(0, 1, x));
            yield return null;
        }

    }

    IEnumerator FadeOutLR()
    {

        float rate = 1.0f / SecondsToFade;

        for (float x = 0.0f; x <= 1.0f; x += Time.deltaTime * rate)
        {
            LR.material.color = new Color(LR.material.color.r, LR.material.color.g, LR.material.color.b, Mathf.Lerp(1, 0, x));
            yield return null;
        }
        
    }

    IEnumerator DestroyLines()
    {
        yield return new WaitForSeconds(SecondsToFade);
        Destroy(this.gameObject);
    }


    IEnumerator InitialiseLineRenderer()
    {
        yield return new WaitForSeconds(.5f);
        LR = GetComponent<LineRenderer>();
        if (LR != null)
        StartCoroutine(FadeInLR());
    }
}
