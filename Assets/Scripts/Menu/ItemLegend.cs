using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLegend : MonoBehaviour
{
    public int legend;
    public Sprite newSpr;

    ControladorMenuInicio manager;


    [SerializeField] string htl;
    [SerializeField] string sh;
    [SerializeField] string tp;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<ControladorMenuInicio>();
    }

    public void Change() 
    {
        manager.imgPrev.sprite = newSpr;
        manager.numLegend = legend;
        PlayerPrefs.SetInt("Legend", manager.numLegend);
        ChangeInfo();
    }

    public void ChangeInfo() 
    {
        manager.healthLegend.text = htl.ToString();
        manager.shieldLegend.text = sh.ToString();
        manager.typeLegend.text = tp.ToString();

        PlayerPrefs.SetString("Health", htl);
        PlayerPrefs.SetString("Shield", sh);
        PlayerPrefs.SetString("Type", tp);
    }

}
