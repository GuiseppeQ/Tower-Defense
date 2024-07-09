using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] enemys;
    public float seconds = 2f;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = seconds;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;    
        if (timer <= 0 )
        {
            SpawnEnemy();
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemys[Random.Range(0,enemys.Length)],transform.position,Quaternion.identity);
        timer = seconds;
    }

}
