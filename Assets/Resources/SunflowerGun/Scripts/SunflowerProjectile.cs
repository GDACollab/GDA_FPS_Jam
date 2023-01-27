using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerProjectile : BaseHitscan
{
    [Header("Sunflower VFX")]
    public Rigidbody trailRigidbody;
    public Rigidbody particleEmitterRigidbody;


    public override void Start()
    {
        Destroy(gameObject, lifespan);

        ApplyRandomSpread();

        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hitInfo, 200.0f, raycastCheckLayers))
        {
            targetPosition = hitInfo.point;
            hasRaycastHit = true;

            if (hitInfo.rigidbody)
            {
                Vector3 forceDirection = hitInfo.transform.position - targetPosition;
                forceDirection = (forceDirection + transform.forward) / 2;

                forceDirection.Normalize();
                hitInfo.rigidbody.AddForce(forceDirection * 100f, ForceMode.Impulse);
            }
        }
        else
        {
            SetTargetPosition(new Ray(Camera.main.transform.position, transform.forward).GetPoint(200));
        }

        ApplyTrailRendererForce();

        if(!hasRaycastHit)
        {
            return;
        }

        ProcessDamage();
    }


    public void ApplyTrailRendererForce()
    {
        Vector3 impulseDirection = transform.forward;
        trailRigidbody.AddForce(impulseDirection * 1000f, ForceMode.VelocityChange);
        particleEmitterRigidbody.AddForce(impulseDirection * 175f, ForceMode.VelocityChange);
    }
}
