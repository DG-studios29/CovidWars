using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject oneGear;
    public GameObject twoGear;
    public GameObject threeGear;
    public GameObject fourGear;


    // Update is called once per frame
    void Update( )
    {

        oneGear.transform.Rotate(0, 0, 1);
        twoGear.transform.Rotate(0, 0, -1);
        threeGear.transform.Rotate(0, 0, 1);
        fourGear.transform.Rotate(0, 0, -1);
    }
}

