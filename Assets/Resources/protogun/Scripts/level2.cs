using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2 : BaseBullet
{

    public override void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();

        // Check if target is a Damageable
        if (damageable != null)
        {
            // If it does, damage the target
            damageable.ProcessDamage(damage);
        }

        OnImpact(collision);

        Destroy(gameObject);
    }
}


