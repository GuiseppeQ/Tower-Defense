using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float oroGratis;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health < 0)
        {
            StartCoroutine(WaitForDead());
        }
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(0.5f);
        Oro.oroActual += oroGratis;
        Destroy(gameObject);
    }
}
