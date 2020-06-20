using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicConfigurator : MonoBehaviour
{
    private void Start()
    {
        UpdateAudio();
        if (PlayerPrefController.GetLoadStatus() == 0)
        {
            OptionsController optionsController = new OptionsController();
            optionsController.Defaults();
            Destroy(optionsController, 1.5f);
            PlayerPrefController.SetAsLoadedBefore();

        }
    }

    public void UpdateAudio()
    {
        AudioSource[] audiosources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audioSource in audiosources)
        {
            audioSource.volume = PlayerPrefController.GetMasterVolume();
        }
    }


}
