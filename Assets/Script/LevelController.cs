using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
  EnemySpawner[] enemySpawners;
  bool check1 = false;
    bool check2 = false;
    bool notinitiated = true;
    [SerializeField] GameObject winScreen = null;
    [SerializeField] AudioSource mainSong = null;
   int checkCounter1 = 0;


    private void Initiate()
    {
        IEnumerator enumerator() { yield return new WaitForSeconds(0.5f);
            winScreen.SetActive(true);
            mainSong.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        StartCoroutine(enumerator());

      
    }

    public void NoMoreEnemies()
    {
        foreach (EnemySpawner enemySpawner in enemySpawners) { enemySpawner.KilSpawning(); }
    }

    private void Update()
    {
        if (check2)
        {
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                if ((enemySpawner.gameObject.GetComponentsInChildren<Transform>().Length - 1) <= 0) { checkCounter1++; }
                else
                {
                    //Debug.Log(enemySpawner.gameObject.GetComponentsInChildren<Transform>().Length);
                    checkCounter1 = 0;
                }
            }
            if (checkCounter1 >= enemySpawners.Length) { check1 = true; }
            else { check1 = false; checkCounter1 = 0; }
        }

     

        if (check1 && check2 && notinitiated) { Initiate(); notinitiated = false; }
        else if (check2 && notinitiated) { StartCoroutine(enumerator()); }
        IEnumerator enumerator() { yield return new WaitForSeconds(15); Initiate(); notinitiated = false; }
    }

    private void Start()
    {
        
       enemySpawners = FindObjectsOfType<EnemySpawner>();
       
    }

    public void Check2Complete()
    {
        check2 = true;
    }

}
