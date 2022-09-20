using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillsPlayr : MonoBehaviour
{
    public int skill1;
    public int skill2;
    public Sprite[] listSpr;
    Caracteristicas caracteristicas;

    //
    bool act1;
    float timer1;
    float time1;
    bool disp1 = true;
    float timerCool1;
    float coolDown1;
    [SerializeField] GameObject spr1;

    bool act2;
    float timer2;
    float time2;
    bool disp2 = true;
    float timerCool2;
    float coolDown2;
    [SerializeField] GameObject spr2;

    //
    [SerializeField] Image img1;    
    [SerializeField] Image img2;


    private void Start()
    {
        skill1 = PlayerPrefs.GetInt("Skill1");
        skill2 = PlayerPrefs.GetInt("Skill2");

        caracteristicas = GameObject.FindGameObjectWithTag("Controlador").GetComponent<Caracteristicas>();

        img1.sprite = listSpr[skill1];
        img2.sprite = listSpr[skill2];

        Aspectos();

    }

    private void Update()
    {
        if (!act1 && !act2) 
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q)) 
            {
                if (disp1) 
                {
                    InputQ();
                }
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.R)) 
            {
                if (disp2) 
                {
                    InputR();
                }
            }
        }

        if (act1) 
        {
            timer1 += Time.deltaTime;
            if (timer1 >= time1) 
            {
                act1 = false;
                timer1 = 0;
                disp1 = false;
                spr1.SetActive(true);
            }
        }

        if (!disp1) 
        {
            timerCool1 -= Time.deltaTime;
            spr1.GetComponent<Image>().fillAmount = timerCool1 / coolDown1;
            if (timerCool1 <= 0) 
            {
                timerCool1 = coolDown1;
                spr1.SetActive(false);
                disp1 = true;
            }
        }

        if (act2)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= time2)
            {
                act2 = false;
                timer2 = 0;
                disp2 = false;
                spr2.SetActive(true);
            }
        }

        if (!disp2)
        {
            timerCool2 -= Time.deltaTime;
            spr2.GetComponent<Image>().fillAmount = timerCool2 / coolDown2;
            if (timerCool2 <= 0)
            {
                timerCool2 = coolDown1;
                spr2.SetActive(false);
                disp2 = true;
            }
        }
    }

    void Aspectos() 
    {
        time1 = caracteristicas.timeActivation[skill1];
        coolDown1 = caracteristicas.cooldown[skill1];
        timerCool1 = coolDown1;

        time2 = caracteristicas.timeActivation[skill2];
        coolDown2 = caracteristicas.cooldown[skill2];
        timerCool2 = coolDown2;
    }

    void InputQ() 
    {
        act1 = true;

        if (skill1 == 0)
        {

        }
        else if (skill1 == 1) 
        {
        }
        else if (skill1 == 2)
        {
        }
        else if (skill1 == 3)
        {
        }
        else if (skill1 == 4)
        {
        }
        else if (skill1 == 5)
        {
        }
        else if (skill1 == 6)
        {
        }
        else if (skill1 == 7)
        {
        }
        else if (skill1 == 8)
        {
        }
        else if (skill1 == 9)
        {
        }
        else if (skill1 == 10)
        {
        }
        else if (skill1 == 11)
        {
        }
        else if (skill1 == 12)
        {
        }
        else if (skill1 == 13)
        {
        }
        else if (skill1 == 14)
        {
        }
        else if (skill1 == 15)
        {
        }
        else if (skill1 == 16)
        {
        }
        else if (skill1 == 17)
        {
        }
        else if (skill1 == 18)
        {
        }
        else if (skill1 == 19)
        {
        }
        else if (skill1 == 20)
        {
        }
        else if (skill1 == 21)
        {
        }
        else if (skill1 == 22)
        {
        }
        else if (skill1 == 23)
        {
        }
        else if (skill1 == 24)
        {
        }

    }

    void InputR()
    {
        act2 = true;

        if (skill1 == 0)
        {

        }
        else if (skill2 == 1)
        {
        }
        else if (skill2 == 2)
        {
        }
        else if (skill2 == 3)
        {
        }
        else if (skill2 == 4)
        {
        }
        else if (skill2 == 5)
        {
        }
        else if (skill2 == 6)
        {
        }
        else if (skill2 == 7)
        {
        }
        else if (skill2 == 8)
        {
        }
        else if (skill2 == 9)
        {
        }
        else if (skill2 == 10)
        {
        }
        else if (skill2 == 11)
        {
        }
        else if (skill2 == 12)
        {
        }
        else if (skill2 == 13)
        {
        }
        else if (skill2 == 14)
        {
        }
        else if (skill2 == 15)
        {
        }
        else if (skill2 == 16)
        {
        }
        else if (skill2 == 17)
        {
        }
        else if (skill2 == 18)
        {
        }
        else if (skill2 == 19)
        {
        }
        else if (skill2 == 20)
        {
        }
        else if (skill2 == 21)
        {
        }
        else if (skill2 == 22)
        {
        }
        else if (skill2 == 23)
        {
        }
        else if (skill2 == 24)
        {
        }
    }


}
