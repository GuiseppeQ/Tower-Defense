using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speedOriginal;

    private void Start()
    {
        speed = speedOriginal;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ResetSpeed()
    {
        speed = speedOriginal;
    }
}