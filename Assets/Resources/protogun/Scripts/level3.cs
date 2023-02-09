using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3: BaseBullet
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
        //i want to make it still do dmg but go through objects but i have no idea how
    }
}


