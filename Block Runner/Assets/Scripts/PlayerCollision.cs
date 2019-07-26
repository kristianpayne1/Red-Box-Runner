using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rigidbody;

    void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            rigidbody.useGravity = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
