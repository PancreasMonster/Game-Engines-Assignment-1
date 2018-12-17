using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseSetter : MonoBehaviour {

    // "Bobbing" animation from 1D Perlin noise.

    // Range over which height varies.
    float heightScale = 15.0f;

    // Distance covered per second along X axis of Perlin plane.
    float xScale;

    void Start()
    {
        xScale = Random.Range(0, 15);
        float height = heightScale * Mathf.PerlinNoise(transform.position.x * xScale, 0.0f) * Mathf.PerlinNoise(transform.position.x * xScale, 0.0f);
        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;
    }

    float SampleCell1(float x, float y)
    {
        return (
         Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100) * 100)
         + (Mathf.PerlinNoise(10000 + x / 1000, 10000 + y / 1000) * 300)
         + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }


    void Update()
    {
        float height = Mathf.PerlinNoise(transform.position.x * xScale, 0.0f) + Mathf.PerlinNoise(transform.position.x * xScale, 0.0f);   //uses perlin noise to set the waypoint heights
        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;
    }
}
