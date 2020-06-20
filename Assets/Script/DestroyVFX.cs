using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFX : MonoBehaviour
{
    ParticleSystem particleSystemForVFX;

 


    private void Update()
    {
        if(particleSystemForVFX.isPlaying == false) { Destroy(gameObject); }
    }

    private void Start()
    {
        particleSystemForVFX = GetComponent<ParticleSystem>();
    }

}
