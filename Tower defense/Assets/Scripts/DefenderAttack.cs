using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;
        }
    }
}
