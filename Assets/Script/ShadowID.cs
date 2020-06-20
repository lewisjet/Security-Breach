using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowID : MonoBehaviour
{
    // private void Update()
    // {
    //    if (FindObjectsOfType<ShadowID>().Length > 1) { Destroy(gameObject); }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
