using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DenfenderState
{
    Idle,
    Walking,
    Attack,
    Died,
}
public class DefenderStateMachine : MonoBehaviour
{
    public DenfenderState State;
    public float range;
    public LayerMask layerMask;
    public DefenderMovement defenderMovement;
    public Animator animator;
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
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, range,layerMask);
            if (hit2D.collider != null)
            {
                State = DenfenderState.Attack;
                defenderMovement.enabled = false;
                animator.SetTrigger("Atack");
            }
        }
    }
}
