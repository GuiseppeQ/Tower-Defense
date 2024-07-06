using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    public float damage;
    public float attackCooldown = 1f; // Tiempo en segundos entre ataques
    private float nextAttackTime;
    public Animator animator;
    public DefenderMovement defenderMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        nextAttackTime = Time.time;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() && Time.time >= nextAttackTime)
        {
            defenderMovement.SetSpeed(0); // Detener el movimiento
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;
            animator.SetTrigger("Atack");
            nextAttackTime = Time.time + attackCooldown; // Actualizar el tiempo para el próximo ataque
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reanudar la velocidad original cuando el Defender salga de la colisión
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            defenderMovement.ResetSpeed();
        }
    }
}
