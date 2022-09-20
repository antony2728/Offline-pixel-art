using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] int cantidad;
    [SerializeField] int enemys;

    public bool act;

    private void Update()
    {
        if (act == true) 
        {
            SpawnEnemys();
        }

    }


    void SpawnEnemys() 
    {
        int random = Random.Range(0, enemyPrefab.Length);
        int spawn = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab[random], spawnPoints[spawn].transform.position, Quaternion.identity);
        cantidad++;
        if (cantidad < enemys)
        {
            Invoke("SpawnEnemys", 0.3f);
        }
        else if (cantidad >= enemys) 
        {
            Destroy(gameObject);
        }
    }
}
