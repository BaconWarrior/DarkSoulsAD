using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    
    public GameObject bonfire;
    public Animator anim;
    public bool dead = false;
    public InventarioJugador ij;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hoguera")) {
            bonfire = other.gameObject;
            bonfire.GetComponentInChildren<ParticleSystem>().Play();
        }

        if (other.CompareTag("clouds"))
        {
            Respawn();
        }
    }

    public void Respawn() {
        EstadisticasJugador.Instance.vida = EstadisticasJugador.Instance.vidaMaxima;
        if (!dead) {
            anim.Play("fade_in");
            dead = true;
            Invoke("Reaparecer", 0.5f);
        }
    }

    public void Reaparecer() {
        transform.position = bonfire.transform.position;
        dead = false;
        ij.RestablecerEstus();
    }
}
