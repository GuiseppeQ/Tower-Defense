using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;

    }
}
