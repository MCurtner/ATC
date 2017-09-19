using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCollisions : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Aircraft")
        {
            Debug.Log("Collision Started.");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Aircraft")
        {
            Debug.Log("Collision Started.");
        }
    }
}
