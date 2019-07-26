using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public Rigidbody rigidbody;

    void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Player")
        {
            rigidbody.useGravity = false;
        }    
    }
}
