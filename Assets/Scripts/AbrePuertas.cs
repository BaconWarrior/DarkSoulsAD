using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrePuertas : MonoBehaviour
{
    public GameObject palanca;
    public GameObject puerta;
    [SerializeField]
    Animator animPalanca;
    [SerializeField]
    Animator animPuerta;
    bool abierto;
    // Start is called before the first frame update
    void Start()
    {
        if (palanca != null)
            animPalanca = palanca.GetComponent<Animator>();
        animPuerta = puerta.GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E) && !abierto)
            {
                abierto = true;
                animPalanca.SetTrigger("Open");
                animPuerta.SetTrigger("Open");
            }
        }
    }
}
