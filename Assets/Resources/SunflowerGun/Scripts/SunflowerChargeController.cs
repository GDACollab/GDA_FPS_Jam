using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SunflowerChargeController : MonoBehaviour
{
    // This feels a lot more hardcodey than I'd like it to be, but fuck it this is a game jam lmao
    // -Enrico

    public FormObject formObject;
    public SunflowerGunAnimator animator;
    public SunflowerGunAnimationEvents events;
    public AudioSource chargingUpSoundSource;


    private void Update()
    {
        // THIS IS JUST TESTING FEEL FREE TO GET RID OF THIS BLOCK
        if (FormController.Instance.FiredGun)
        {
            events.PlayFireMainSound();
            return;
        }

        if (!FormController.Instance._isReloading &&
            formObject._currentPrimaryEnergy != 0 &&
            FormController.Instance._currentPrimaryIsPressed &&
            formObject._currentPrimaryCooldown <= 0)
        {
            if (!chargingUpSoundSource.isPlaying)
            {
                chargingUpSoundSource.Play();
                // Probably play Charge animation here
            }

            // Formula for getting % of charge done
            // FormController.Instance._currentPrimaryHoldDuration / formObject.primaryForm.maxHoldDuration
        }
        else
        {
            
            if (chargingUpSoundSource.isPlaying)
            {
                // Need to let the charging sound ring out after firing otherwise it'll sound jarring
                if (formObject._currentPrimaryCooldown <= 0)
                {
                    chargingUpSoundSource.Stop();
                }

                // And go back to Idle animation here
            }
        }
    }
}
