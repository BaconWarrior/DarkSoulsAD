using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ches : MonoBehaviour
{
    public Collider Activacion;
    public GameObject pivote;
    public int arma;
    
    [SerializeField]
    private string _arma;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("Entro Player");
            Activacion.enabled = false;
            other.GetComponent<InventarioJugador>().ObtenerArma(arma);
            LeanTween.rotateZ(pivote, 130, 3);
            EstadisticasJugador.Instance.NuevaNotificacion("Obtuviste " + _arma);
        }
    }

}
