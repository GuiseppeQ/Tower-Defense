using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Segundos : MonoBehaviour
{
    public TMP_Text textoOro;
    public float time;

    void Update()
    {
        time += Time.deltaTime;
        int wholeSeconds = Mathf.FloorToInt(time); // Convierte a entero truncando los decimales
        textoOro.text = "Seconds: " + wholeSeconds;
    }
}
