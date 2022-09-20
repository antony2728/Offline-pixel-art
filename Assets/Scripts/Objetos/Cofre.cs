using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    Animator anim;
    bool abierto = false;
    [SerializeField] Transform point;
    [SerializeField] GameObject[] listaItems;

    [SerializeField] GameObject canvasText;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (abierto == false) 
            {
                canvasText.SetActive(true);
                if (Input.GetKey(KeyCode.E)) 
                {
                    anim.SetTrigger("Abrir");
                    Abrir();
                    abierto = true;
                    canvasText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (abierto == false)
            {
                canvasText.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    anim.SetTrigger("Abrir");
                    Abrir();
                    abierto = true;
                    canvasText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (abierto == false) 
            {
                canvasText.SetActive(false);
            }
        }
    }

    void Abrir() 
    {
        int numAzar = Random.Range(0, listaItems.Length);
        GameObject item = Instantiate(listaItems[numAzar], point.position, Quaternion.identity);
    }
}
