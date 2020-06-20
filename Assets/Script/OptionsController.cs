using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Slider difficultySlider = null;

    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] int defaultDifficulty  = 3;
    [SerializeField] bool SettingsMenu = false;

    MusicConfigurator musicConfigurator;

    // Start is called before the first frame update
    void Start()
    {
        if (SettingsMenu)
        {
            volumeSlider.value = PlayerPrefController.GetMasterVolume();
            difficultySlider.value = PlayerPrefController.GetDifficulty();
        }
        musicConfigurator = FindObjectOfType<MusicConfigurator>();
    }

  public  void SaveAndQuit()
    {
        PlayerPrefController.SetMasterVolume(volumeSlider.value);
        PlayerPrefController.SetDifficulty(Mathf.RoundToInt (difficultySlider.value));
    }

    public void Defaults()
    {
        PlayerPrefController.SetMasterVolume(defaultVolume);
        PlayerPrefController.SetDifficulty(defaultDifficulty);
        if (SettingsMenu) { Start(); }
    }

    private void Update()
    {
        musicConfigurator.UpdateAudio();
       
    }

}
