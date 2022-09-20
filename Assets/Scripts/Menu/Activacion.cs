using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activacion : MonoBehaviour
{
    public GameObject pnlPlay;
    public GameObject pnlChamps;
    public GameObject pnlSkills;
    public GameObject pnlStore;

    public GameObject pnlActivo;

    private void Start()
    {
        pnlActivo = pnlPlay;
        pnlPlay.SetActive(true);
    }

    public void PanelPlay()
    {
        pnlActivo.SetActive(false);
        pnlPlay.SetActive(true);
        pnlActivo = pnlPlay;
    }

    public void PanelChamps()
    {
        pnlActivo.SetActive(false);
        pnlChamps.SetActive(true);
        pnlActivo = pnlChamps;
    }

    public void PanelSkills()
    {
        pnlActivo.SetActive(false);
        pnlSkills.SetActive(true);
        pnlActivo = pnlSkills;
    }

    public void PanelStore()
    {
        pnlActivo.SetActive(false);
        pnlStore.SetActive(true);
        pnlActivo = pnlStore;
    }
}
