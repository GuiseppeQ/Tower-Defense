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
    public DefenderAttack defenderAttack;
   

    public float rangeOriginal;

    void Start()
    {
        rangeOriginal = range;
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
        if (defenderAttack == null)
        {
            defenderAttack = GetComponent<DefenderAttack>();
        }


    }


    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
        if (State == DefenderState.Walking)
        {
            if (hit2D.collider != null)
            {
                animator.SetTrigger("Atack");
                range = 0;
                State = DefenderState.Attack;
                defenderMovement.enabled = false;             
            }
        }
        if (State == DefenderState.Attack)
        {
            
            State = DefenderState.Walking;
        }
        if (vida.health < 0)
        {
            State = DefenderState.Died;
            animator.SetTrigger("Dead");
        }
        if (hit2D.collider == null)
        {
           range = rangeOriginal;

            if(defenderAttack.Base==true)
            {
                defenderMovement.speed = defenderMovement.speedOriginal;
            }
          ;
        }
        defenderMovement.enabled = true;
    }
}