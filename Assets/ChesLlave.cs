using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesLlave : MonoBehaviour
{
    public Collider Activacion;
    public GameObject pivote;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activacion.enabled = false;
            EstadisticasJugador.Instance.LlaveFinal = true;
            LeanTween.rotateZ(pivote, 130, 3);
            EstadisticasJugador.Instance.NuevaNotificacion("Obtuviste Llave de la tumba prohibida");
        }
    }
}
