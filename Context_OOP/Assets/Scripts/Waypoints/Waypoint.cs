using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Waypoint : MonoBehaviour
{
    public float waitSeconds;
    public float speedOut;

    void Update()
    {
        waitSeconds = Random.Range(0, 10);
        speedOut = Random.Range(1, 3);
    }
}