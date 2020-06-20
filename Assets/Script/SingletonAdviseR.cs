using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonAdviseR : MonoBehaviour
{
    int buildIndex;

    private void Awake()
    {
        if (FindObjectsOfType<SingletonAdviseR>().Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }



  public  void SetBuildIndex()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

   public int GetBuildIndex()
    {
        return buildIndex;
    }
}
