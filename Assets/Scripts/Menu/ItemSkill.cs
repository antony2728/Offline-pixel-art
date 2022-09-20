using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSkill : MonoBehaviour
{
    public int numSkill;

    ControladorMenuInicio manager;
    Image myImg;

    private void Start()
    {
        myImg = GetComponent<Image>();
        manager = GameObject.Find("Manager").GetComponent<ControladorMenuInicio>();
    }

    public void Change()
    {
        if (manager.act1)
        {
            manager.numSkill1 = numSkill;
            manager.img1.sprite = myImg.sprite;
            PlayerPrefs.SetInt("Skill1", manager.numSkill1);
        }
        else if (manager.act2)
        {
            manager.numSkill2 = numSkill;
            manager.img2.sprite = myImg.sprite;
            PlayerPrefs.SetInt("Skill2", manager.numSkill2);
        }
    }
}
