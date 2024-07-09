using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravity : MonoBehaviour
{
    public LayerMask groundLayer; // La capa que representa el suelo (Tilemap)
    public float extraGravity = 10f; // La cantidad de gravedad extra a aplicar cuando no se detecta suelo
    public float rayLength = 0.1f; // La longitud del raycast
    private Rigidbody2D rb;
    private float originalGravityScale;
    public EnemyMovement enemyMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        // Lanza un raycast hacia abajo para detectar el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (hit.collider == null)
        {
            // Si no se detecta suelo, aumenta la gravedad
            rb.gravityScale = originalGravityScale + extraGravity;
        }
        else
        {
            // Si se detecta suelo, usa la gravedad original
            rb.gravityScale = originalGravityScale;
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar el raycast en la escena para depuración
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
