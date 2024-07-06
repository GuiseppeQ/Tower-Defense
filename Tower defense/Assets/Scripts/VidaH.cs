using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaH : MonoBehaviour
{

    public float health;
    public float maxHealth = 30;
    public EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            enemyMovement.speed = enemyMovement.speedOriginal;
            StartCoroutine(WaitForDead());
        }
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
