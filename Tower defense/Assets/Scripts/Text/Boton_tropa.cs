using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_tropa : MonoBehaviour
{
    public int  costo;
    public GameObject tropaPrefab;

    private void OnMouseDown()
    {
        Oro adminOro = FindObjectOfType<Oro>();

        if (adminOro != null)
        {
            adminOro.ComprarTropa(costo, tropaPrefab);
        }
    }
}