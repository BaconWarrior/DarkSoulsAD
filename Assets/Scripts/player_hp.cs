using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
            spawn.Respawn();
        }
        if (spawn.dead) {
            hp = max_hp;
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
