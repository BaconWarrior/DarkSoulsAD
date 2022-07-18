using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palaca : MonoBehaviour
{
    public Elevador elev;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                elev.Activarse();
        }
    }
}
