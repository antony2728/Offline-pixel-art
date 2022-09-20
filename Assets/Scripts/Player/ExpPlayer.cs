using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpPlayer : MonoBehaviour
{
    public float exp;
    public float maxExp;

    public int level;

    [SerializeField] Image expBar;
    [SerializeField] Text lvlText;

    private void Start()
    {
        exp = PlayerPrefs.GetFloat("Experiencia");
        maxExp = PlayerPrefs.GetFloat("maxExperiencia");
        level = PlayerPrefs.GetInt("level");
    }

    private void Update()
    {
        exp = Mathf.Clamp(exp, 0, maxExp);
        expBar.fillAmount = exp / maxExp;

        lvlText.text = level.ToString();

        if (exp >= maxExp) 
        {
            level += 1;
            exp = 0;
            ActualizarMaxExp();
        }
    }

    void ActualizarMaxExp() 
    {
        if (level == 1) 
        {
            maxExp = 200;
        }
        else if (level == 2)
        {
            maxExp = 400;
        }
        else if (level == 3)
        {
            maxExp = 800;
        }
        else if (level == 4)
        {
            maxExp = 1600;
        }
        else if (level == 5)
        {
            maxExp = 3200;
        }
        else if (level == 6)
        {
            maxExp = 6400;
        }
        else if (level == 7)
        {
            maxExp = 12800;
        }
        else if (level == 8)
        {
            maxExp = 25600;
        }
        else if (level == 9)
        {
            maxExp = 51200;
        }
        else if (level == 10)
        {
            maxExp = 102400;
        }
    }
}
