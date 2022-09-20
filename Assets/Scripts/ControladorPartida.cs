using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPartida : MonoBehaviour
{
    int start;
    int first;
    int numLegend;

    public int Nivel;
    public int subNivel;
    public string world;

    [SerializeField] Text level;
    [SerializeField] Transform pointStart;

    [SerializeField] List<GameObject> listPrefabLegends;

    private void Awake()
    {
        start = PlayerPrefs.GetInt("partidaEmpezada");
        first = PlayerPrefs.GetInt("primerNivel");
        numLegend = PlayerPrefs.GetInt("Legend");
        GameObject newPlayer = Instantiate(listPrefabLegends[numLegend], pointStart.position, Quaternion.identity);
        level = GameObject.FindGameObjectWithTag("TextLevel").GetComponent<Text>();
    }

    private void Start()
    {

        if (start == 1) 
        {
            if (first == 1)
            {
                Nivel++;
                PlayerPrefs.SetInt("nivel", Nivel);
                subNivel++;
                PlayerPrefs.SetInt("subnivel", subNivel);
            }
            else if (first == 0) 
            {
                Nivel = PlayerPrefs.GetInt("nivel");
                subNivel = PlayerPrefs.GetInt("subnivel");
                subNivel++;
                PlayerPrefs.SetInt("subnivel", subNivel);
                if (subNivel > 5) 
                {
                    subNivel = 1;
                    Nivel++;
                    PlayerPrefs.SetInt("nivel", Nivel);
                    PlayerPrefs.SetInt("subnivel", subNivel);
                }
            }
        }

        level.text = "Nivel " + Nivel.ToString() + " - " + subNivel.ToString(); 
    }
}
