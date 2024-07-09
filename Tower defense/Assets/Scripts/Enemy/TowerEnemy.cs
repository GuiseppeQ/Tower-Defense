using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerEnemy : MonoBehaviour
{
    public float maxhealth = 20;
    public float currentHealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        slider.maxValue = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {

            Destroy(gameObject);

        }
    }
}
