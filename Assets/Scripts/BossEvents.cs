using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvents : MonoBehaviour
{
    static readonly int an_Charge = Animator.StringToHash("Charge");
    static readonly int an_Run = Animator.StringToHash("Run");
    static readonly int an_Walk = Animator.StringToHash("Walk");
    static readonly int an_Roar = Animator.StringToHash("Roar");
    static readonly int an_Dead = Animator.StringToHash("Dead");
    static readonly int an_Dizzy = Animator.StringToHash("Dizzy");
    public Behaviour Tree;
    bool carga;
    Rigidbody rb;
    Animator anim;
    public GameObject reinicioPos;
    public Transform posJugador;
    public Vector3 target;
    public LayerMask layerBoss;
    public float hp;
    public GameObject Charco;
    public GameObject ZonaDaño;
    public Behaviour navigator;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (carga)
        {
            // The step size is equal to speed times frame time.
            float step = 20 * Time.deltaTime;
            
            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.localPosition, target, step);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Tree.enabled = false;
        }
    }
    public void Carga()
    {
        ZonaDaño.SetActive(true);
        carga = true;
        anim.Play(an_Charge);
        //target = posJugador.position;
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("MuroBoss"))
        {
            if(carga)
            {
                ZonaDaño.SetActive(false);
                anim.Play(an_Dizzy);
                carga = false;
                rb.velocity = Vector3.zero;
                Invoke(nameof(Reinicio), 4);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MuroBoss"))
        {
            if (carga)
            {
                ZonaDaño.SetActive(false);
                print("Ouch, choque :c");
                anim.Play(an_Dizzy);
                carga = false;
                rb.velocity = Vector3.zero;
                transform.LookAt(reinicioPos.transform);
                Invoke(nameof(Reinicio), 4);
            }
        }
        if (other.CompareTag("Arma"))
        {
            hp -= EstadisticasJugador.Instance.dano;
            if (hp <= 0 && !dead)
            {
                dead = true;
                Tree.enabled = false;
                carga = false;
                rb.velocity = Vector3.zero;
                navigator.enabled = false;
                anim.SetTrigger("Dead");
                anim.Play(an_Dead);
                Destroy(this.gameObject, 8);
            }
        }
    }

    public void ElejirAtaque()
    {
        Tree.enabled = false;
        int eleccion = Random.Range(0, 2);
        print("Eleccion" + eleccion);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerBoss))
        {
            target = hit.point;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        if (eleccion == 1)
        {
            Spit();
        }
        else
        {
            print("Escupitajo");
            Spit();
        }
    }

    void Reinicio()
    {
        anim.Play(an_Walk);
        LeanTween.move(this.gameObject, reinicioPos.transform, 3.0f);
        Invoke(nameof(EncenderTree), 3.0f);
    }

    void EncenderTree()
    {
        Tree.enabled = true;
    }


    public void Spit()
    {
        GameObject temp = Instantiate(Charco, null);
        temp.transform.position = posJugador.position;
        Invoke(nameof(EncenderTree), 1.0f);
    }
}
