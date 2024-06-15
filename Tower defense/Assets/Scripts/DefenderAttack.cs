using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    public float damage;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;
            animator.SetTrigger("Atack");
        }
    }
}
