using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

[CreateAssetMenu(menuName = "Forms/protogun_secondary Form")]
public class protogun_secondary : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject _bullet1;
    public GameObject _bullet2;
    public GameObject _bullet3;
    public LayerMask raycastCheckLayers;

    public float chargeTime;

    public float chargeThreshold1;
    public float chargeThreshold2;
    public float chargeThreshold3;

    public float charge;

    

    //FormAction() is called each time the form "shoots".
    public override void FormAction(float context)
    {
        
        chargeTime = FormController.Instance._currentSecondaryHoldDuration;  //it took me 5 hours to figure this out 
        screenShakeImpulseMagnitude = 0.1f;

        void runAction(GameObject bulletnum)
        {
            base.FormAction(-1);
            //Spawn bullet prefab at weapon's barrel position
            var bullet = Instantiate(bulletnum, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
            SpawnedGarbageController.Instance.AddAsChild(bullet);
            RaycastHit info;

            // Raycast into world from camera position + direction, if target found, set bullet target position to that point, else, bullet direction mimics player camera.
            // This allows us to shoot these projectile bullets from the gun rather than the center of the screen to get the desired appearance
            // If the weapon were hitscan, we could skip this and just add tracers from the gun to the desired destination
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out info, 200.0f, raycastCheckLayers))
            {
                var pos = info.point;
                bullet.GetComponent<BaseBullet>().SetTargetPosition(pos);
            }
            else
            {
                var dir = PlayerController.Instance._playerCamera.forward;
                bullet.GetComponent<BaseBullet>().SetDirection(dir);
            }
            charge = chargeTime;
            chargeTime = 0;
        }

        if (chargeTime < chargeThreshold1)
        {
            charge = chargeTime;
            chargeTime = 0;
        }


        if (chargeTime >= chargeThreshold1 && chargeTime < chargeThreshold2)
        {
 
            screenShakeImpulseMagnitude *= 10;
            runAction(_bullet1);

        }
        else if (chargeTime >= chargeThreshold2 && chargeTime < chargeThreshold3)
        {
            
            screenShakeImpulseMagnitude *= 50;
            runAction(_bullet2);

        }
        else if (chargeTime >= chargeThreshold3)
        {
            
            screenShakeImpulseMagnitude *= 500;
            runAction(_bullet3);

        }
    }
}
       

    


