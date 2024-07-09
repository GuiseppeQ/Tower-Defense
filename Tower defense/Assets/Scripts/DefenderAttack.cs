using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    public float damage;
    public Animator animator;
    public DefenderMovement defenderMovement;
    public EnemyHealth enemyHealth;

    void Start()
    {
        animator = GetComponent<Animator>();

        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            defenderMovement.speed = 0;
        }
    }

    public void DealDamageToEnemy()
    {
        enemyHealth.health -= damage;
        // Realizar otras acciones como reproducir animaciones, etc.
    }
}
