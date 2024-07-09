using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DefenderState
{
    Idle,
    Walking,
    Attack,
    Died,
}

public class DefenderStateMachine : MonoBehaviour
{
    public DefenderState State;
    public float range;
    public LayerMask layerMask;
    public DefenderMovement defenderMovement;
    public Animator animator;
    public VidaH vida;
    public DefenderAttack attack;

    private float nextAttackTime;
    public float attackCooldown = 1f; // Tiempo en segundos entre ataques

    void Start()
    {
        nextAttackTime = Time.time;
        State = DefenderState.Walking;
        animator = GetComponent<Animator>();

        if (defenderMovement == null)
        {
            defenderMovement = GetComponent<DefenderMovement>();
        }
        if (vida == null)
        {
            vida = GetComponent<VidaH>();
        }
        if (attack == null)
        {
            attack = GetComponent<DefenderAttack>();
        }
    }


    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
        if (State == DefenderState.Walking)
        {
            if (hit2D.collider != null)
            {
                
                State = DefenderState.Attack;
                defenderMovement.enabled = false;
                animator.SetTrigger("Atack");              
              
            }
        }
        if (State == DefenderState.Attack)
        {
            if (Time.time >= nextAttackTime)
            {
                attack.DealDamageToEnemy(); 
                nextAttackTime = Time.time + attackCooldown; // Actualizar el tiempo para el próximo ataque
            }
            State = DefenderState.Walking;
        }
        if (vida.health < 0)
        {
            State = DefenderState.Died;
            animator.SetTrigger("Dead");
        }
        if (hit2D.collider == null)
        {

            defenderMovement.speed = defenderMovement.speedOriginal;
        }
        defenderMovement.enabled = true;
    }
}