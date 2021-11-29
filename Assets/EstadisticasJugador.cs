using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class EstadisticasJugador : MonoBehaviour
{
    public float vida;
    public float vidaMaxima;
    public float energia;
    public float energiaMaxima;
    public float dano;
    public float regEner;
    public SpawnController spawn;


    public Slider barraVida;
    public Slider barraEnergia;

    static EstadisticasJugador instance;
    public static EstadisticasJugador Instance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        spawn = gameObject.GetComponent<SpawnController>();
    }

    public void RecibirDano(float dano)
    {
        vida -= dano;
        if (vida > vidaMaxima)
            vida = vidaMaxima;
        if (vida < 0)
            vida = 0;
        barraVida.value = vida / vidaMaxima;
        print(vida);
    }
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            spawn.Respawn();
        }
        if (spawn.dead)
        {
            vida = vidaMaxima;
        }
        if(energia < energiaMaxima)
        {
            actualizarBarraEnergia(regEner * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.R))
            Rodar();
    }

    void actualizarBarraEnergia(float _energia)
    {
        energia += _energia;
        if (energia > energiaMaxima)
            energia = energiaMaxima;
        barraEnergia.value = energia / energiaMaxima;
    }

    

    void Rodar()
    {
        actualizarBarraEnergia(-20.0f);
        print("Ruedo");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("acido"))
        {
            RecibirDano(1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rasgunho"))
        {
            RecibirDano(10);
        }
    }

}
