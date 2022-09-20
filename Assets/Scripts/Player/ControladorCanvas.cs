using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCanvas : MonoBehaviour
{
    public bool lvTerminada;

    [SerializeField] GameObject mnPausa;
    float timer;
    [SerializeField] Animator anim;

    public string nameWorld;


    int newnum;
    int numTerminar = 0;

    private void Start()
    {
        newnum = PlayerPrefs.GetInt("primerNivel");
        nameWorld = GameObject.Find("ControladorPartida").GetComponent<ControladorPartida>().world;
    }

    private void Update()
    {
        if (lvTerminada) 
        {
            anim.SetTrigger("Final");
            timer += Time.deltaTime;
            if (timer >= 3) 
            {
                if (newnum == 1)
                {
                    newnum = 0;
                    PlayerPrefs.SetInt("primerNivel", newnum);
                }
                SceneManager.LoadScene(nameWorld);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mnPausa.activeInHierarchy == false) 
            {
                mnPausa.SetActive(true);
            }
            else if (mnPausa.activeInHierarchy == true)
            {
                mnPausa.SetActive(false);
            }
        }
    }

    public void TerminarPartida() 
    {
        PlayerPrefs.SetInt("partidaEmpezada", numTerminar);
        PlayerPrefs.SetInt("primerNivel", numTerminar);
        SceneManager.LoadScene(0);
    }
}

