using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaControlador : MonoBehaviour
{
    Animator anim;
    [SerializeField] SpawnEnemy spawnEnemy;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Abierta", true);
            if (spawnEnemy.act == false) 
            {
                spawnEnemy.act = true;
            }
        }
    }
}
