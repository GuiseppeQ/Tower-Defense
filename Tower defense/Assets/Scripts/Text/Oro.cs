using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oro : MonoBehaviour
{
    public float oroInicial = 0;
    public float tasaIncrementoOro = 1f;
    public Transform puntoDespliegueTropa;
    public static float oroActual;
    public static Oro instance { get; set;}

    void Start()
    {
        oroActual = oroInicial;
    }

    void Update()
    {
        oroActual += tasaIncrementoOro * Time.deltaTime; // Incrementa el oro con el tiempo
    }

    public void ComprarTropa(int costo, GameObject tropaPrefab)
    {
        if (oroActual >= costo)
        {
            oroActual -= costo; // Resta el costo de la tropa al oro actual
            DesplegarTropa(tropaPrefab);
        }
        else
        {
            Debug.Log("¡No tienes suficiente oro!");
        }
    }

    void DesplegarTropa(GameObject tropaPrefab)
    {
        Instantiate(tropaPrefab, puntoDespliegueTropa.position, Quaternion.identity);
    }
}




