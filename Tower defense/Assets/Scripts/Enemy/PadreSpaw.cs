using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreSpaw : MonoBehaviour
{
    public GameObject[] spaw;
    public float seconds = 2f;
    public int maxActiveSpawns = 3; // Número máximo de spawns activos a la vez
    private float timer;
    private List<GameObject> activeSpawns;

    void Start()
    {
        timer = seconds;
        activeSpawns = new List<GameObject>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (activeSpawns.Count < maxActiveSpawns)
        {
            // Encuentra un spawn inactivo
            GameObject spawn = FindInactiveSpawn();
            if (spawn != null)
            {
                spawn.SetActive(true);
                activeSpawns.Add(spawn);
                StartCoroutine(DeactivateSpawn(spawn));
            }
        }
        timer = seconds;
    }

    GameObject FindInactiveSpawn()
    {
        foreach (GameObject spawn in spaw)
        {
            if (!spawn.activeInHierarchy)
            {
                return spawn;
            }
        }
        return null;
    }

    IEnumerator DeactivateSpawn(GameObject spawn)
    {
        yield return new WaitForSeconds(seconds);
        spawn.SetActive(false);
        activeSpawns.Remove(spawn);
    }

    public void ActivateSpaw()
    {
        enabled = true;
    }

    public void DeactivateSpaw()
    {
        enabled = false;
    }
}

