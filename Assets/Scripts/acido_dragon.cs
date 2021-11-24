using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acido_dragon : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDisable()
    {
        GameObject instance = Instantiate(this.gameObject,transform.parent);
        instance.transform.localPosition = transform.localPosition;
        instance.SetActive(true);
    }
}
