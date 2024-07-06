using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 30;
    public DefenderMovement defenderMovement;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        defenderMovement = FindObjectOfType<DefenderMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            defenderMovement.speed = defenderMovement.speedOriginal;
            StartCoroutine(WaitForDead());
        }
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(0.5f); 
        Destroy(gameObject);
    }


}
