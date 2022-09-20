using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControladorMenuInicio : MonoBehaviour
{
    [SerializeField] int numStart;
    [SerializeField] float numMaxExp;
    [SerializeField] int levelmin;

    int num;
    int num2;

    //new
    public int numSkill1;
    public int numSkill2;
    public string sceneStart;
    public GameObject parentPlanet;
    public RectTransform planet;
    public List<Sprite> listSpr;
    public Image img1;
    public Image img2;
    public bool act1 = false;
    public bool act2 = false;
    public List<Sprite> listLegend;
    public int numLegend;
    public Image imgPrev;
    [SerializeField] Animator animator;

    public bool com = false;
    public bool start;

    //
    public TextMeshProUGUI healthLegend;
    public TextMeshProUGUI shieldLegend;
    public TextMeshProUGUI typeLegend;

    public string health;
    public string shield;
    public string type;

    private void Start()
    {

        num = PlayerPrefs.GetInt("partidaEmpezada");
        num2 = PlayerPrefs.GetInt("primerNivel");

        //new
        planet = parentPlanet.transform.GetChild(0).GetComponent<RectTransform>();
        sceneStart = "Map1";
        numSkill1 = PlayerPrefs.GetInt("Skill1");
        numSkill2 = PlayerPrefs.GetInt("Skill2");
        act1 = true;

        img1.sprite = listSpr[numSkill1];
        img2.sprite = listSpr[numSkill2];

        numLegend = PlayerPrefs.GetInt("Legend");
        imgPrev.sprite = listLegend[numLegend];

        health = PlayerPrefs.GetString("Health");
        shield = PlayerPrefs.GetString("Shield");
        type = PlayerPrefs.GetString("Type");


        ColocarDatosLegend();
    }

    private void Update()
    {
        if (start) 
        {
            EmpezarNuevaPartida();
        }   
    }

    public void ActAnim() 
    {
        com = true;
    }


    void ColocarDatosLegend() 
    {
        healthLegend.text = health.ToString();
        shieldLegend.text = shield.ToString();
        typeLegend.text = type.ToString();
    }

    private void FixedUpdate()
    {
        animator.SetBool("Start", com);
    }

    public void EmpezarNuevaPartida()
    {
        PlayerPrefs.SetInt("partidaEmpezada", numStart);
        PlayerPrefs.SetInt("primerNivel", numStart);
        PlayerPrefs.SetFloat("Experiencia", levelmin);
        PlayerPrefs.SetFloat("maxExperiencia", numMaxExp);
        PlayerPrefs.SetInt("level", levelmin);
        PlayerPrefs.SetInt("Gun", 0);
        SceneManager.LoadScene(sceneStart);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    /// 

    public void Refort()
    {
        Destroy(planet.gameObject);
    }

    public void Act1()
    {
        act1 = true;
        act2 = false;
    }

    public void Act2()
    {
        act1 = false;
        act2 = true;
    }
}
