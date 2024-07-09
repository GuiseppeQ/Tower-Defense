using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public float damage;
    public float damageTower;
    public Animator animator;
    public EnemyMovement enemyMovement;
    public VidaH vidaH;

    void Start()
    {
        animator = GetComponent<Animator>();

        vidaH = FindObjectOfType<VidaH>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<VidaH>())
        {
            enemyMovement.speed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            collision.gameObject.GetComponent<TowerHealth>().currentHealth -= damageTower;
            Destroy(gameObject);
        }
    }
    public void DealDamageToDefender()
    {
        vidaH.health -= damage;
        // Realizar otras acciones como reproducir animaciones, etc.
    }
}
