using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventarioJugador : MonoBehaviour
{
    int anilloEspecial, llaveJefe, cantidadObj1, cantidadObj2, cantidadObj3;
    [SerializeField]
    int objetoSeleccionado = 0;
    public List<Consumibles> objetos = new List<Consumibles>();
    public Image imgObj;
    public TextMeshProUGUI cantidadObj;
    float regEnNormal;
    // Start is called before the first frame update
    void Start()
    {
        regEnNormal = EstadisticasJugador.Instance.regEner;
        cantidadObj1 = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            ObjSelec(1);
        if (Input.GetKeyDown(KeyCode.C))
            ObjSelec(-1);
        if (Input.GetKeyDown(KeyCode.Q))
            ConsumirObjeto();
    }
    [Serializable]
    public struct Consumibles
    {
        public int id;
        public string nombre;
        public Sprite icono;
    }

    void ConsumirObjeto()
    {
        if(objetoSeleccionado == 0)
        {
            if (cantidadObj1 > 0)
            {
                cantidadObj1--;
                cantidadObj.text = cantidadObj1.ToString();
                EstadisticasJugador.Instance.RecibirDano(-30);
            }
        }
        if(objetoSeleccionado == 1)
        {
            if (cantidadObj2 > 0)
            {
                cantidadObj2--;
                cantidadObj.text = cantidadObj2.ToString();
                EstadisticasJugador.Instance.regEner = 9;
                Invoke(nameof(RegNormal), 8);
            }
        }
        if(objetoSeleccionado == 2)
        {
            if (cantidadObj3 > 0)
            {
                cantidadObj3--;
                cantidadObj.text = cantidadObj3.ToString();
                //EstadisticasJugador.Instance.RecibirDano(-30);
            }
        }
        
        
    } 
    void RegNormal()
    {
        EstadisticasJugador.Instance.regEner = regEnNormal;
    }
    void ObjSelec(int id)
    {
        objetoSeleccionado += id;
        if (objetoSeleccionado == 3)
            objetoSeleccionado = 0;
        if (objetoSeleccionado == -1)
            objetoSeleccionado = 2;
        imgObj.sprite = objetos[objetoSeleccionado].icono;
        if (objetoSeleccionado == 0)
            cantidadObj.text = cantidadObj1.ToString();
        if (objetoSeleccionado == 1)
            cantidadObj.text = cantidadObj2.ToString();
        if (objetoSeleccionado == 2)
            cantidadObj.text = cantidadObj3.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Tesoro"))
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                Destroy(other.gameObject);
                int desicion = UnityEngine.Random.Range(0, 2);
                if (desicion == 1)
                {
                    cantidadObj2++;
                    if (objetoSeleccionado == 1)
                        cantidadObj.text = cantidadObj2.ToString();
                }
                else
                {
                    cantidadObj3++;
                    if (objetoSeleccionado == 2)
                        cantidadObj.text = cantidadObj3.ToString();
                }
            }
        }
    }
}
