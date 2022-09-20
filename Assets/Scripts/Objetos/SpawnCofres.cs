using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCofres : MonoBehaviour
{
    [SerializeField] List<Transform> puntos;
    [SerializeField] GameObject prefabCofre;
    int rand;

    private void Start()
    {
        rand = Random.Range(0, puntos.Count);
        Instantiate(prefabCofre, puntos[rand].transform.position, Quaternion.identity);
    }
}
