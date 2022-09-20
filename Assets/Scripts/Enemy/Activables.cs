using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activables : MonoBehaviour
{
    public void Activar() 
    {
        gameObject.SetActive(true);
    }

    public void Desactivar() 
    {
        gameObject.SetActive(false);
    }

}
