using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cost_Text : MonoBehaviour
{
    public TMP_Text textoOro;
    public Boton_tropa boton_Tropa;

    void Update()
    {
        ActualizarTextoCosto();
    }

    public void ActualizarTextoCosto()
    {
        textoOro.text = "Costo: " + boton_Tropa.costo;
    }
}
