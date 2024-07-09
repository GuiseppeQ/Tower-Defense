using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    public float damage;
    public float damageTower;
    public float attackCooldown = 1f; // Tiempo en segundos entre ataques
    private float nextAttackTime;
    public Animator animator;
    public DefenderMovement defenderMovement;
    public DefenderStateMachine defenderStateMachine;

    void Start()
    {
        animator = GetComponent<Animator>();
        defenderMovement = GetComponent<DefenderMovement>(); // Asegura que enemyMovement no sea nulo
        defenderStateMachine = GetComponent<DefenderStateMachine>(); // Asegura que enemyStateMachine no sea nulo
        nextAttackTime = Time.time;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            defenderMovement.speed = 7;
        }

        if (collision.gameObject.GetComponent<TowerEnemy>())
        {
            collision.gameObject.GetComponent<TowerEnemy>().currentHealth -= damageTower;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            defenderMovement.speed = defenderMovement.speedOriginal;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() && Time.time >= nextAttackTime)
        {
            defenderMovement.speed = 0.3f;
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;
            animator.SetTrigger("Atack");
            nextAttackTime = Time.time + attackCooldown; // Actualizar el tiempo para el pr�ximo ataque

            if (defenderStateMachine != null && collision.gameObject.GetComponent<EnemyHealth>().health <= 1)
            {
                defenderStateMachine.range = defenderStateMachine.rangeOriginal;
                defenderMovement.speed = defenderMovement.speedOriginal;
            }
        }

        if (collision.gameObject.GetComponent<DefenderMovement>() != null && collision.gameObject.GetComponent<DefenderMovement>().speed <= 0.7f)
        {
            defenderMovement.speed = 0.3f;
        }
        else if (collision.gameObject.GetComponent<DefenderMovement>() != null && collision.gameObject.GetComponent<DefenderMovement>().speed > 0.3f)
        {
            defenderMovement.speed = defenderMovement.speedOriginal;
        }
    }
}

