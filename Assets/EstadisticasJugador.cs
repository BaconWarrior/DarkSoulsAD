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

    public Animator animator;
    [Header("Attacks")]
    private float originalSpeed;
    public float attackMoveSpeed;
    [Header("Weapon Colliders")]
    public Collider swordCollider;
    public Collider axeCollider;
    public Collider maceCollider;
    public Collider swordTwoCollider;

    public Collider activeWeaponCollider;
    public float attackTime;
    public Collider fireCollider;
    public ParticleSystem fireParticles;
    public float fireTimeActivate;
    public float fireTimeActive;

    private bool busy;

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
        originalSpeed = gameObject.GetComponent<CMF.SimpleWalkerController>().movementSpeed;
        activeWeaponCollider = swordCollider;
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
        if (!busy)
        {
            if (Input.GetKeyDown(KeyCode.N))
                StartCoroutine(activateAttack());
            if (Input.GetKeyDown(KeyCode.M))
                StartCoroutine(activateFire());
        }
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

    IEnumerator activateAttack()
    {
        busy = true;
        gameObject.GetComponent<CMF.SimpleWalkerController>().movementSpeed = attackMoveSpeed;
        animator.SetTrigger("Attack");
        activeWeaponCollider.enabled = true;
        yield return new WaitForSeconds(attackTime);
        activeWeaponCollider.enabled = false;
        busy = false;
        gameObject.GetComponent<CMF.SimpleWalkerController>().movementSpeed = originalSpeed;
    }

    IEnumerator activateFire()
    {
        busy = true;
        gameObject.GetComponent<CMF.SimpleWalkerController>().movementSpeed = attackMoveSpeed;
        animator.SetTrigger("Fire");
        fireParticles.Play();
        yield return new WaitForSeconds(fireTimeActivate);
        fireCollider.enabled = true;
        StartCoroutine(activeFire());
    }

    IEnumerator activeFire()
    {

        yield return new WaitForSeconds(fireTimeActive);
        fireCollider.enabled = false;
        busy = false;
        fireParticles.Stop();
        gameObject.GetComponent<CMF.SimpleWalkerController>().movementSpeed = originalSpeed;

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
