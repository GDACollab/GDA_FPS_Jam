using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerGunAnimator : MonoBehaviour
{
    // TODO: Putting this here cuz I know for a fact you will see this lmao
    //       Be sure to go into weapon_info.json and update the model path
    //       to point to the one you're gonna add
    //
    //       Also be sure to set up a transform at the end of the barrel
    //       for the bullet spawn

    [Header("Animation References")]


    [Space(15)]
    public ParticleSystem steamBarrel;
    public ParticleSystem steamReloadEjection;
    public ParticleSystem muzzleFlash;


    [Header("Misc. References")]
    public AudioSource audioSource;


    public void PlayAudio(AudioClip toPlay, float volume = 1f)
    {
        audioSource.PlayOneShot(toPlay, volume);
    }

    public void PlayParticleEmitter(ParticleSystem toPlay)
    {
        toPlay.Play();
    }
}
