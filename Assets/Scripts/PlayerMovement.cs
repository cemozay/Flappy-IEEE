using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float speed0 =0;
    public float jump;
    bool isJump= true;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed*speed0, rb.velocity.y, rb.velocity.z);
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.useGravity = true;
            speed0 = 1;
        }
    }

    void Jump()
    {
        if (isJump == true)
        {
            rb.AddForce(0, jump*100, 0);
            isJump = false;
            Invoke("JumpTrue", 0.2f);
        }
    }

    void JumpTrue()
    {
        isJump = true;
    }
}
