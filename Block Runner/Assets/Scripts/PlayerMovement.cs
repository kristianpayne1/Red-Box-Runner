using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce = 1000;
    public float sidewaysForce = 50;

    void FixedUpdate()
    {
        rigidbody.AddForce(0,0,forwardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0 ,0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a"))
        {
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0 ,0, ForceMode.VelocityChange);
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                float touchPower = (touch.position.x - Screen.width / 2) / (Screen.width / 2);
                if(touch.position.x > Screen.width / 2)
                {
                    rigidbody.AddForce(sidewaysForce * Time.deltaTime*touchPower, 0 ,0, ForceMode.VelocityChange);
                }else
                {
                    rigidbody.AddForce(-sidewaysForce * Time.deltaTime*-touchPower, 0 ,0, ForceMode.VelocityChange);
                }
            }
        }

        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }

    void touchMovement(float direction)
    {
        Debug.Log(direction);
    }
}
