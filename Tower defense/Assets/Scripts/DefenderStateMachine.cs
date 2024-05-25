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
    // Start is called before the first frame update
    void Start()
    {
        State = DenfenderState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == DenfenderState.Idle)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, range,layerMask);
            if (hit2D.collider != null)
            {
                State = DenfenderState.Walking;
            }
        }
    }
}
