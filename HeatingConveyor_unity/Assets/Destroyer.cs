using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float distance = 1;
    public Vector3 direction;

    public void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * distance, Color.white);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            if (hit.collider.tag == tag)
            {
                DestroyImmediate(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * distance, Color.white);
        }
    }
}
