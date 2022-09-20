using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    public string newScene;
    public GameObject prefabPlanet;

    ControladorMenuInicio control;

    private void Start()
    {
        control = GameObject.Find("Manager").GetComponent<ControladorMenuInicio>();
    }

    public void Change()
    {
        control.sceneStart = newScene;
        GameObject newPlanet = Instantiate(prefabPlanet, control.planet.position, Quaternion.identity);
        control.Refort();
        newPlanet.transform.SetParent(control.parentPlanet.transform);
        control.planet = newPlanet.GetComponent<RectTransform>();
    }
}
