using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject bonfire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        transform.position = bonfire.transform.position;
    }
}
