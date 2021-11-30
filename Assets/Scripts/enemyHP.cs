using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public float hp = 5;
    public EstadisticasJugador jugador;

    // Start is called before the first frame update
    private void Awake()
    {
        jugador = GameObject.FindObjectOfType<EstadisticasJugador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arma")) {
            hp -= jugador.dano;
        }
    }
}
