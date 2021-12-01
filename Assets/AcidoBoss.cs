using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidoBoss : MonoBehaviour
{
    public float tiempoMuerte;
    private void Start()
    {
        Invoke(nameof(Desaparecer), tiempoMuerte);
    }
    

    void Desaparecer()
    {
        Destroy(gameObject);
    }
}
