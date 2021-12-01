using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            EstadisticasJugador.Instance.RecibirDano(20.0f);
        }
    }
}
