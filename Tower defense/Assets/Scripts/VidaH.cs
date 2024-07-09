using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaH : MonoBehaviour
{
    public float health;
    public float maxHealth = 30;

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
        Destroy(gameObject);
    }
}
