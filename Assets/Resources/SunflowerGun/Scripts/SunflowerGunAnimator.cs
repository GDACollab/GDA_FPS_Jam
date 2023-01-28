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
    private SunflowerChargeController controller;

    private bool isCharging = false;
    private bool isCurrentlyADS = false;

    private float adsValue = 0f;
    private float adsTarget = 0f;

    [Header("Audio References")]
    public AudioSource chargingUpSoundSource;
    public AudioSource miscAudioSource;
    [Space(15)]
    public AudioSource adsAudioSource;
    public AudioClip adsOnSound;
    public AudioClip adsOffSound;

    [Header("Misc. References")]
    public GameObject lorePopupPrefab;


    private void Awake()
    {
        controller = GetComponent<SunflowerChargeController>();
    }

    private void Start()
    {
        currentPlayerStatus = FormController.Instance;
    }

    private void Update()
    {
        if( adsTarget == 0 )
        {
            // We are exiting out of ADS
            adsValue = SunflowerMath.Approach( adsValue, adsTarget, .5f, Time.deltaTime );
        }
        else
        {
            // We are entering ADS
            adsValue = SunflowerMath.Approach( adsValue, adsTarget, .05f, Time.deltaTime );
        }
        
        animator.SetFloat( "ADSValue", adsValue );

        if( isCharging )
        {
            animator.SetFloat( "ChargeValue", currentPlayerStatus._currentPrimaryHoldDuration / currentPlayerStatus.currentForm.primaryForm.maxHoldDuration );
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

    public GameObject SpawnLorePopup()
    {
        return Instantiate(lorePopupPrefab);
    }
#endregion

    public void Draw()
    {
        animator.SetTrigger("Draw");
    }

#region ADS Functions
    public void TurnOnADS()
    {
        isCurrentlyADS = true;
        adsTarget = 1f;

        adsAudioSource.Stop();
        adsAudioSource.PlayOneShot(adsOnSound, 1f);
    }

    public void TurnOffADS()
    {
        isCurrentlyADS = false;
        adsTarget = 0f;
        
        adsAudioSource.Stop();
        adsAudioSource.PlayOneShot(adsOffSound, 1f);
    }
#endregion

#region Charge Functions
    public void BeginCharge()
    {
        isCharging = true;

        animator.SetFloat("ChargeValue", 0f );
        animator.SetTrigger("BeginCharge");

        chargingUpSoundSource.Play();
    }

    private void StopCharge(bool stopChargingSound = true)
    {
        isCharging = false;
        if (stopChargingSound)
        {
            chargingUpSoundSource.Stop();
        }
    }

    public void CancelCharge()
    {
        StopCharge();

        animator.SetTrigger("CancelCharge");
    }
#endregion

#region Shooting Functions
    public void Shoot()
    {
        StopCharge(false);

        animator.SetTrigger("Fire");
    }

    public void ShootingDone()
    {
        controller.mainStateMachine.firingState.AnimDone();
    }
#endregion

#region Reload Functions
    public void Reload()
    {
        animator.SetTrigger("Reload");
    }
#endregion

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
