using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum DefenderState
    {
        Idle,
        Walking,
        Attack,
        Died,
    }

    public DefenderState State;
    public float range;
    public LayerMask layerMask;
    public EnemyMovement enemyMovement;
    public Animator animator;
    public EnemyHealth enemyHealth;  // Asegúrate de tener una referencia a EnemyHealth
    public EnemyAtack enemyAttack;  // Asegúrate de tener una referencia a EnemyAttack

    private float nextAttackTime;
    public float attackCooldown = 1f; // Tiempo en segundos entre ataques

    void Start()
    {
        nextAttackTime = Time.time;
        State = DefenderState.Walking;
        animator = GetComponent<Animator>();

        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }

        // Obtener la referencia a EnemyHealth específica de este enemigo
        enemyHealth = GetComponent<EnemyHealth>();

        // Obtener la referencia a EnemyAttack específica de este enemigo
        enemyAttack = GetComponent<EnemyAtack>();
    }

    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.left, range, layerMask);

        if (State == DefenderState.Walking)
        {
            if (hit2D.collider != null)
            {
                State = DefenderState.Attack;
                enemyMovement.enabled = false;
                animator.SetTrigger("Atack");
            }
        }

        if (State == DefenderState.Attack)
        {
            if (Time.time >= nextAttackTime)
            {
                // Llamar al método DealDamageToDefender en EnemyAttack específico de este enemigo
                enemyAttack.DealDamageToDefender();
                nextAttackTime = Time.time + attackCooldown; // Actualizar el tiempo para el próximo ataque
            }
            State = DefenderState.Walking;
        }

        if (enemyHealth.health < 0)
        {
            State = DefenderState.Died;
            animator.SetTrigger("Dead");
        }

        if (hit2D.collider == null)
        {
            enemyMovement.speed = enemyMovement.speedOriginal;
        }

        enemyMovement.enabled = true;
    }
}
