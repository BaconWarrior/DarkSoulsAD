using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acido_dragon : MonoBehaviour
{
    public float tiempoMuerte;
    private void Start()
    {
        Invoke(nameof(Desaparecer), tiempoMuerte);
    }
    // Start is called before the first frame update
    private void OnDisable()
    {
        GameObject instance = Instantiate(this.gameObject,transform.parent);
        instance.transform.localPosition = transform.localPosition;
        instance.SetActive(true);
    }

    void Desaparecer()
    {
        Destroy(gameObject);
    }
}
