using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       IEnumerator enumerator()
        {
            yield return new WaitForEndOfFrame();
            FindObjectOfType<SingletonAdviseR>().SetBuildIndex();
        }

        StartCoroutine(enumerator());

    }

   
}
