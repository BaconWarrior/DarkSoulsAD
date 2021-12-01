using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ches : MonoBehaviour
{
    public Collider Activacion;
    public GameObject pivote;
    public int arma;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("Entro Player");
            Activacion.enabled = false;
            //other.GetComponentInChildren<InventarioJugador>().ObtenerArma(arma);
            LeanTween.rotateZ(pivote, 130, 3);
        }
    }

}
