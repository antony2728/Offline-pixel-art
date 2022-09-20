using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorEspera : MonoBehaviour
{
    [SerializeField] float tiempo;
    [SerializeField] GameObject rawImage;
    [SerializeField] GameObject objVida;
    [SerializeField] GameObject objExp;
    [SerializeField] GameObject levelTx;
    [SerializeField] GameObject objSkills;

    float timer;

    [SerializeField] ControladorCanvas cnCon;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tiempo)
        {
            rawImage.SetActive(true);
            objVida.SetActive(true);
            objExp.SetActive(true);
            levelTx.SetActive(true);
            objSkills.SetActive(true);
            timer = Time.deltaTime;
        }

        if (cnCon.lvTerminada == true) 
        {
            rawImage.SetActive(false);
            objVida.SetActive(false);
            objExp.SetActive(false);
            levelTx.SetActive(false);
            objSkills.SetActive(false);
        }
    }
}
