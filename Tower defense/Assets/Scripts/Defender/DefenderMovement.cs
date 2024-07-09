using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speedOriginal;

    void Start()
    {
        speed = speedOriginal;
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;
    }


}