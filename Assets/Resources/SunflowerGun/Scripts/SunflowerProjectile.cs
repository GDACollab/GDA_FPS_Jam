using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerProjectile : BaseHitscan
{
    public Rigidbody trailRigidbody;


    public override void Start()
    {
        Destroy(gameObject, lifespan);

        ApplyRandomSpread();

        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hitInfo, 200.0f, raycastCheckLayers))
        {
            targetPosition = hitInfo.point;
            hasRaycastHit = true;
        }
        else
        {
            SetTargetPosition(new Ray(Camera.main.transform.position, transform.forward).GetPoint(200));
        }

        
        if(!hasRaycastHit)
        {
            return;
        }

        ApplyTrailRendererForce();

        ProcessDamage();
    }


    public void ApplyTrailRendererForce()
    {
        Vector3 impulseDirection = transform.forward;
        trailRigidbody.AddForce(impulseDirection * 500f, ForceMode.VelocityChange);
    }
}
