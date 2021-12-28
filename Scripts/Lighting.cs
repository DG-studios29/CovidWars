using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public Light myLight;

    void Update( )
    {
        myLight.intensity = Mathf.PingPong(Time.time, 5);
    }
}
