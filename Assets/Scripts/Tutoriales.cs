using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoriales : MonoBehaviour
{
    [SerializeField]
    private string instruccion;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            
            EstadisticasJugador.Instance.NuevaNotificacion("Presiona " + instruccion);
        }
    }
}
