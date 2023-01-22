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

    private bool isCharging = false;

    private void Update()
    {
        // If we are ready to shoot
        if (!FormController.Instance._isReloading &&
            formObject._currentPrimaryEnergy != 0 &&
            formObject._currentPrimaryCooldown <= 0)
        {
            if( FormController.Instance._currentPrimaryIsPressed )
            {
                // We are in the same frame as when we clicked
                if (!isCharging)
                {
                    animator.BeginCharge();
                }
            }
            else
            {
                // We are in the same frame as when we release the button
                if (isCharging)
                {
                    // TODO: Run checks on if we need to cancel charge animation or shoot
                    
                    // Need to let the charging sound ring out after firing otherwise it'll sound jarring
                    if (formObject._currentPrimaryCooldown <= 0)
                    {
                        animator.Shoot();
                    }
                }
            }
        }
        else
        {
            
            
        }
    }
}
