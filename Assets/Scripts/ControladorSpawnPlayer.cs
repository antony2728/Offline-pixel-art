using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSpawnPlayer : MonoBehaviour
{
    ControladorCanvas contCn;
    ExpPlayer exp;


    [SerializeField] GameObject cnPulsar;

    private void Start()
    {
        contCn = GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorCanvas>();
        exp = GameObject.FindGameObjectWithTag("Player").GetComponent<ExpPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (contCn.lvTerminada == false) 
        {
            if (collision.CompareTag("Player"))
            {
                cnPulsar.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    contCn.lvTerminada = true;
                    CapturarDatos();
                    Destroy(cnPulsar);

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (contCn.lvTerminada == false) 
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    contCn.lvTerminada = true;
                    CapturarDatos();
                    Destroy(cnPulsar);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (contCn == false) 
            {
                cnPulsar.SetActive(false);
            }
        }
    }


    void CapturarDatos() 
    {
        PlayerPrefs.SetFloat("Experiencia", exp.exp);
        PlayerPrefs.SetFloat("maxExperiencia", exp.maxExp);
        PlayerPrefs.SetInt("level", exp.level);
    }
}
