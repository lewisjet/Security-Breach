using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Space] [Header ("FOR LOADING SCREENS")]
    [SerializeField] GameObject soundPlayer = null;

    AudioSource audioSource;


    void Start()
    {
        
        if (soundPlayer != null) { audioSource = soundPlayer.GetComponent<AudioSource>(); StartCoroutine(SplashScreenCarryOn()) ; }
    }

    IEnumerator SplashScreenCarryOn()
    {
        yield return !audioSource.isPlaying;
        yield return new WaitForSeconds(1);
        LoadNextScene();
        
         
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ForceLoad(int buildSceneIndex)
    {
        SceneManager.LoadScene(buildSceneIndex);
    }

    public void ForceLoadViaStringRef(string stringRef)
    {
        SceneManager.LoadScene(stringRef);
    }

    public void LoadLastLevel()
    {
     SceneManager.LoadScene ( FindObjectOfType<SingletonAdviseR>().GetBuildIndex());
    }

   
}
