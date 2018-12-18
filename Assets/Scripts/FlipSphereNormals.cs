using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSphereNormals : MonoBehaviour {

    public int xSize, ySize;
    public float delay;
    bool changeColour = true;

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;



        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] *= -1;
        }

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for(int t = 0; t < tris.Length; t += 3)
            {
                int temp = tris[t];
                tris[t] = tris[t + 1];
                tris[t + 1] = temp;
            }
            mesh.SetTriangles(tris, i);
        }

        Texture2D sphTexture = new Texture2D(xSize, ySize, TextureFormat.ARGB32, false);


        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                sphTexture.SetPixel(x, y, Random.ColorHSV(.5f, 1, .5f, 1, .5f, 1, 1, 1));
            }
        }

        // Apply all SetPixel calls
        sphTexture.Apply();

        // connect texture to material of GameObject this script is attached to
        GetComponent<Renderer>().material.mainTexture = sphTexture;
    }

    void Update()
    {
       
    }

   

}
