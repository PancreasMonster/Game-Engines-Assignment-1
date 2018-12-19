using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

    public float wpNum, gapSize;
    float gapPrev;
    public float radius;
    public GameObject waypoint, spawner;
    public Vector3 pos, currentPos;
    public bool test, first;

    // Use this for initialization
    void OnEnable()
    {
        gapPrev = 0;
        for (int i = 0; i < wpNum; i++)
        {

            float gap = Random.Range(-2.5f, 2.5f);
            pos = transform.TransformPoint(radius * Mathf.Sin(i*2*Mathf.PI/wpNum), -radius * Mathf.Cos(i * 2 * Mathf.PI / wpNum), i * .1f);
            gapPrev += gap;
            GameObject Clone = Instantiate(waypoint, pos, Quaternion.identity);
            if (first)
            Clone.transform.tag = ("Waypoint");
            Clone.name = "Waypoint " + i;
            Clone.GetComponent<LineBeat>().AssignBandNum(Mathf.FloorToInt(i * (511 / wpNum)));
            currentPos = Clone.transform.position;
            if (first && i == wpNum - 1)
            {
                GameObject Spawner1 = Instantiate(spawner, new Vector3(pos.x + 1, pos.y+radius, pos.z), Quaternion.identity);
                Spawner1.GetComponent<Spawner>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetPos(Vector3 pos)
    {
        return currentPos;
    }

    public float GetRadius(float rad)
    {
        return radius;
    }
}
