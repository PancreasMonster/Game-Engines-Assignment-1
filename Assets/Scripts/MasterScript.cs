using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    [Range(0, 1000)]
    public int zigZagLenght, loopLenght, corkscrewLenght, figureEightLenght;
    [Range(0, 10)]
    public float corkscrewRadius, corkscrewNum, figureEightRadius, figureEightNum;
    [Range(0, 50)]
    public float loopRadius;

   // connects to all the spawners and ensures a proper build of the procedural rollercoaster

}
