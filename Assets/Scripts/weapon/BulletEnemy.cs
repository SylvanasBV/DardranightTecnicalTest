using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqu� puedes manejar el da�o al jugador
            Destroy(gameObject);
        }
        else if (other.CompareTag("MapLimit"))
        {
            Destroy(gameObject); // Se destruye al tocar el borde del mapa
        }
    }
}
