using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Items : MonoBehaviour
{
    [SerializeField] GameObject cnText;
    [SerializeField] string nombreItem;
    [SerializeField] Text txObj;

    private void Start()
    {
        txObj.text = nombreItem + " Recoger con E";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cnText.SetActive(true);
            if (Input.GetKey(KeyCode.E)) 
            {
                //Uso(collision);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cnText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                //so(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cnText.SetActive(false);
        }
    }

    /*void Uso(Collider2D collision) 
    {
        if (nombreItem == "Poción Vida")
        {
            if (collision.GetComponent<VidaPlayer>().htl >= 100)
            {
                Debug.Log("Vida Completa");
            }
            else if (collision.GetComponent<VidaPlayer>().htl <= 50)
            {
                collision.GetComponent<VidaPlayer>().htl += 50f;
                Destroy(gameObject);
            }
        }
        else if (nombreItem == "Poción Experiencia") 
        {
            ExpPlayer expPlayer = collision.GetComponent<ExpPlayer>();
            float rand = Random.Range(0, expPlayer.maxExp);
            expPlayer.exp += rand;
            Destroy(gameObject);

        }
    }*/

}
