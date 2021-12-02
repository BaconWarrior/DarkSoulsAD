using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroQuemable : MonoBehaviour
{
    public float dissolveRate = 0.2f;
    public float refreshRate;
    public float dieDelay;
    public bool quemandose;
    public Material dissolveMaterials;
    public GameObject particulas;
    public bool entradaCastillo = false;

    private void OnDestroy()
    {
        if (entradaCastillo) {
            print("desprender suelo");
            GameObject suelo = GameObject.FindGameObjectWithTag("sueloFragil");
            suelo.GetComponent<Rigidbody>().isKinematic = false;
            for (int i = 0; i < suelo.transform.childCount; i++) {
                print("Derrumbe");
                //suelo.transform.GetChild(i).gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("fuego"))
        {
          
            quemandose = true;
            particulas.SetActive(true);
            StartCoroutine(Dissolve());
            
        }
    }


    IEnumerator Dissolve()
    {
        int IdDissolveAmount = Shader.PropertyToID("DissolveAmount_");
        dissolveMaterials.SetFloat(IdDissolveAmount, -1);
        yield return new WaitForSeconds(dieDelay);

        float counter = -1;

            WaitForSeconds rr = new WaitForSeconds(refreshRate);
            while (dissolveMaterials.GetFloat(IdDissolveAmount) < 1)
            {
                counter += dissolveRate;
                dissolveMaterials.SetFloat(IdDissolveAmount, counter);
                yield return rr;
            }
        dissolveMaterials.SetFloat(IdDissolveAmount, -1);
        Destroy(gameObject, 1f);
    }
}
