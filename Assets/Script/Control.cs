using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Control : MonoBehaviour
{

    Slider slider;
    bool check2 = false;
 [Range (0,100)] [SerializeField]   byte currentTime = 1;
    [Tooltip("How many enemies need to be killed to progress!")] [SerializeField] int riotSeverity = 1;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = riotSeverity;
        StartCoroutine(Enumerator());

        IEnumerator Enumerator() { yield return new WaitForEndOfFrame(); Time.timeScale = currentTime;

        }
    }

  public  void ChangeControl(float controlChange)
    {
        float trueControlChange = Mathf.Clamp(controlChange, Mathf.NegativeInfinity , slider.maxValue);
        if (slider.value + trueControlChange < slider.minValue) { trueControlChange = slider.value * -1; }
        slider.value += trueControlChange;

    }

    private void Update()
    {
        if ((slider.value >= slider.maxValue) && !check2)
        {
            LevelController levelController = FindObjectOfType<LevelController>();
            levelController.Check2Complete();
            levelController.NoMoreEnemies();
            check2 = true;

        }
    }

    public void NextLVL()
    {
        Time.timeScale = currentTime;
        StartCoroutine(Enumerator());
        IEnumerator Enumerator() { yield return new WaitForEndOfFrame(); SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }

    }

    public float GetPreviousTimeScale() { return currentTime; }


}
