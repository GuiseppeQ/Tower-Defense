using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum DenfenderState
    {
        Idle,
        Walking,
        Attack,
        Died,
    }
    public DenfenderState State;
    public float range;
    public LayerMask layerMask;
    public EnemyMovement enemyMovement;
    public Animator animator;
    public EnemyHealth vida;


    // Start is called before the first frame update
    void Start()
    {
        State = DenfenderState.Walking;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (State == DenfenderState.Walking)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
            if (hit2D.collider != null)
            {

                State = DenfenderState.Attack;
                enemyMovement.enabled = false;
                animator.SetTrigger("Atack");
            }
           
        }
        //if (State == DenfenderState.Attack)
        //{
            
        //    State = DenfenderState.Walking;
        //}

        if (vida.health < 0)
        {
            State = DenfenderState.Died;
            animator.SetTrigger("Dead");
        }
        enemyMovement.enabled = true;
    }
}
