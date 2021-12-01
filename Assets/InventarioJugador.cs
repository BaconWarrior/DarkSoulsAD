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
    int armaSelec = 0;
    public List<Consumibles> objetos = new List<Consumibles>();
    List<GameObject> armas = new List<GameObject>();
    public Image imgObj;
    public TextMeshProUGUI cantidadObj;
    float regEnNormal;
    [SerializeField]
    GameObject espadaNueva;
    [SerializeField]
    GameObject mazo;
    [SerializeField]
    GameObject hacha;
    public GameObject ArmaActual;
    // Start is called before the first frame update
    void Start()
    {
        regEnNormal = EstadisticasJugador.Instance.regEner;
        cantidadObj1 = 5;
        armas.Add(ArmaActual);
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
        if (Input.GetKeyDown(KeyCode.L))
            ArmaSelec(1);
        if (Input.GetKeyDown(KeyCode.K))
            ArmaSelec(-1);
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

    public void ObtenerArma(int id)
    {
        switch (id)
        {
            case 0:
                armas.Add(espadaNueva);
                break;
            case 1:
                armas.Add(mazo);
                break;
            case 2:
                armas.Add(hacha);
                break;
        }
    }

    void ArmaSelec(int id)
    {
        ArmaActual.SetActive(false);
        armaSelec += id;
        if (armaSelec == armas.Count)
            armaSelec = 0;
        if (armaSelec == -1)
            armaSelec = armas.Count - 1;
        ArmaActual = armas[armaSelec];
        ArmaActual.SetActive(true);
        ///Se�alizar la variable que Juan va a poner
    }
}
