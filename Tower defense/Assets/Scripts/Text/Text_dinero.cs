using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text_dinero : MonoBehaviour
{
    public TMP_Text textoOro;


    void Update()
    {
        ActualizarTextoOro();
    }

    public void ActualizarTextoOro()
    {
        textoOro.text = "Oro: " + Mathf.RoundToInt(Oro.oroActual);
    }
}
