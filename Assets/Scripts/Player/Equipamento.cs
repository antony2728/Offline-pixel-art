using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipamento : MonoBehaviour
{
    public GameObject[] guns;
    public int nameGun;

    Transform posArma;
    PlayerController playerController;

    private void Awake()
    {
        nameGun = PlayerPrefs.GetInt("Gun");
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        posArma = GameObject.FindGameObjectWithTag("PosArma").GetComponent<Transform>();

        if (nameGun > 0) 
        {
            GameObject newArma = Instantiate(guns[nameGun]);
            newArma.GetComponent<Transform>().SetParent(posArma);
            newArma.GetComponent<Transform>().position = posArma.position;
            newArma.GetComponent<Transform>().rotation = Quaternion.identity;
            newArma.GetComponent<Gun>().take = true;
            playerController.algunTomado = true;
            playerController.typeGun = newArma.GetComponent<Gun>().type;
            playerController.daño = newArma.GetComponent<Gun>().dañoAsignar;
        }
    }

}
