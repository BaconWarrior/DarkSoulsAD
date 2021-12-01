using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public GameObject boss;
    public Transform posEntrada;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (EstadisticasJugador.Instance.LlaveFinal)
            {
                print("Emtrada bossFinal");
                boss.SetActive(true);
                collision.transform.position = posEntrada.position;
                gameObject.SetActive(false);
            }
        }
    }
}
