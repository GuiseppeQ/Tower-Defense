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

    public float rangeOriginal;


    void Start()
    {
        rangeOriginal = range;
        State = DefenderState.Walking;
        animator = GetComponent<Animator>();

        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }

        // Obtener la referencia a EnemyHealth específica de este enemigo
        enemyHealth = GetComponent<EnemyHealth>();

        // Obtener la referencia a EnemyAttack específica de este enemigo
       
    }

    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.left, range, layerMask);

        if (State == DefenderState.Walking)
        {
            if (hit2D.collider != null)
            {
                animator.SetTrigger("Atack");
                range = 0;
                State = DefenderState.Attack;
                enemyMovement.enabled = false;
                
            }
        }

        if (State == DefenderState.Attack)
        {
            
            State = DefenderState.Walking;
        }

        if (enemyHealth.health <= 0)
        {
            State = DefenderState.Died;
            animator.SetTrigger("Dead");
            Oro.oroActual += 0.001f;
        }

        if (hit2D.collider == null)
        {
           range=rangeOriginal;
           
           //enemyMovement.speed = enemyMovement.speedOriginal;          
        }
        enemyMovement.enabled = true;
    }
}
