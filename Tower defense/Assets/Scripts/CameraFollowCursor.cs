using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{
    public float velocidadMovimiento = 10f; // Velocidad a la que se moverá la cámara
    public float limiteIzquierdo = -10f; // Límite izquierdo de la cámara
    public float limiteDerecho = 10f; // Límite derecho de la cámara

    void Update()
    {
        // Obtener la posición del cursor en la pantalla
        Vector3 posicionCursor = Input.mousePosition;

        // Convertir la posición del cursor a coordenadas del mundo
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionCursor);

        // Obtener la posición actual de la cámara
        Vector3 posicionCamara = transform.position;

        // Calcular la nueva posición de la cámara basada en la posición horizontal del cursor
        posicionCamara.x = Mathf.Lerp(posicionCamara.x, posicionMundo.x, velocidadMovimiento * Time.deltaTime);

        // Aplicar los límites para que la cámara no se salga del área del juego
        posicionCamara.x = Mathf.Clamp(posicionCamara.x, limiteIzquierdo, limiteDerecho);

        // Establecer la nueva posición de la cámara
        transform.position = posicionCamara;
    }
}