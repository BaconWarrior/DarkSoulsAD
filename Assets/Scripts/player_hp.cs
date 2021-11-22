using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour
{
    public float max_hp;
    public float hp;
    public SpawnController spawn;

    private void Start()
    {
        hp = max_hp;
        spawn = gameObject.GetComponent<SpawnController>();
    }

    public void RecibirDano(float dano) {
        hp -= dano;
        print(hp);
    }

    private void Update()
    {
        if (hp <= 0) {
            hp = max_hp;
            spawn.Respawn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("acido")) {
            RecibirDano(1f*Time.deltaTime);
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
