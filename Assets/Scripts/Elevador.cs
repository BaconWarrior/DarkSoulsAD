using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public Transform posBajo;
    public Transform posAlto;
    public GameObject elevador;
    bool desbloqueado;
    public bool desbloqueador;
    public void Activarse()
    {
        if(elevador.transform.position == posBajo.position && desbloqueado)
        {
            Debug.Log("Moviendose hacia arriba");
            LeanTween.move(elevador, posAlto, 8.0f);
        }
        else if (elevador.transform.position == posAlto.position && desbloqueado)
        {
            Debug.Log("Moviendose hacia abajo");
            LeanTween.move(elevador, posBajo, 8.0f);
        }
        else
        {
            EstadisticasJugador.Instance.NuevaNotificacion("El mecanismo no se mueve");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!desbloqueado && desbloqueador)
            desbloqueado = true;
        if(collision.transform.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                Activarse();
        }
    }
}
