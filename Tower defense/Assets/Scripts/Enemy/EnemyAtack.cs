using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public float damage;
    public float damageTower;
    public float attackCooldown = 1f; // Tiempo en segundos entre ataques
    private float nextAttackTime;
    public Animator animator;
    public EnemyMovement enemyMovement;
    public EnemyStateMachine enemyStateMachine;
    public EnemyHealth enemyHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>(); // Asegura que enemyMovement no sea nulo
        enemyStateMachine = GetComponent<EnemyStateMachine>(); // Asegura que enemyStateMachine no sea nulo
        enemyHealth = GetComponent<EnemyHealth>();
        nextAttackTime = Time.time;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<VidaH>() && Time.time >= nextAttackTime)
        {
            //enemyMovement.speed = 0.5f;
            collision.gameObject.GetComponent<VidaH>().health -= damage;
            animator.SetTrigger("Atack");
            nextAttackTime = Time.time + attackCooldown; // Actualizar el tiempo para el próximo ataque

            if (enemyStateMachine != null && collision.gameObject.GetComponent<VidaH>().health <= 1)
            {
                enemyStateMachine.range = enemyStateMachine.rangeOriginal;
                enemyMovement.speed = enemyMovement.speedOriginal;
            }
        }

        //if (collision.gameObject.GetComponent<EnemyMovement>() != null && collision.gameObject.GetComponent<EnemyMovement>().speed <= 0.7f)
        //{
        //    enemyMovement.speed = 0.5f;
        //}
        //else if (collision.gameObject.GetComponent<EnemyMovement>() != null && collision.gameObject.GetComponent<EnemyMovement>().speed > 0.7f)
        //{
        //    enemyMovement.speed = enemyMovement.speedOriginal;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            if(enemyHealth.health >1)
            {
                collision.gameObject.GetComponent<TowerHealth>().currentHealth -= damageTower;
                Destroy(gameObject);
            }      
        }
        if (collision.gameObject.GetComponent<TowerEnemy>())
        {
            enemyMovement.speed = 7;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TowerEnemy>())
        {
            enemyMovement.speed = enemyMovement.speedOriginal;
        }
    }
}
