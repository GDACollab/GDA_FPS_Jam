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

    private FormController currentPlayerStatus;
    [SerializeField] private Animator animator;

    private bool isCharging = false;
    // private bool reloadingAnimationPlayed = false;

    [Header("Audio References")]
    public AudioSource chargingUpSoundSource;
    public AudioSource miscAudioSource;

    private void Start()
    {
        currentPlayerStatus = GameObject.Find("Player").GetComponent<FormController>();
    }

    private void Update()
    {
        // Check animation states
        // This is the only place where these animation parameters are altered
        // Feel free to remove these and set the animation up how you want
 
        // animController.SetBool("Fire", isFiring() && !isReloading());

        // if (isReloading() && !reloadingAnimationPlayed)
        // {
        //     animController.SetTrigger("Reload");
        //     reloadingAnimationPlayed = true;
        // }

        // if (!isReloading())
        // {
        //     reloadingAnimationPlayed = false;
        // }

        if( isCharging )
        {
            animator.SetFloat("ChargeValue", currentPlayerStatus._currentPrimaryHoldDuration / currentPlayerStatus.currentForm.primaryForm.maxHoldDuration );
        }
    }

#region Misc Functions
    public void PlayAudio(AudioClip toPlay, float volume = 1f)
    {
        miscAudioSource.PlayOneShot(toPlay, volume);
    }

    public void PlayParticleEmitter(ParticleSystem toPlay)
    {
        toPlay.Play();
    }
#endregion

    public void BeginCharge()
    {
        isCharging = true;

        animator.SetTrigger("BeginCharge");

        chargingUpSoundSource.Play();
    }

    private void StopCharge()
    {
        isCharging = false;
        chargingUpSoundSource.Stop();
    }

    public void CancelCharge()
    {
        StopCharge();

        animator.SetTrigger("CancelCharge");
    }

    public void Shoot()
    {
        StopCharge();

        animator.SetTrigger("Fire");
    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
    }

#region Helper methods
    // Helper Methods
    // Note: currentPlayerStatus has access to more information
    // To see check the script FormController.cs, attached to the Player gameObject
    public bool isADS(){ return currentPlayerStatus.isADS; }

    public bool isReloading() { return currentPlayerStatus._isReloading; }

    public bool isFiring() { return currentPlayerStatus.FiredGun; }

    public bool isHoldingDownPrimary() { return (currentPlayerStatus._currentPrimaryHoldDuration > 0); }

    public bool isHoldingDownSecondary() { return (currentPlayerStatus._currentSecondaryHoldDuration > 0); }
#endregion
}
