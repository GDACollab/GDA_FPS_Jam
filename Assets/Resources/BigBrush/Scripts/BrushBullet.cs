using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushBullet : BaseBullet
{
    // Amount of drop the bullet has
    public float gravity = -9.8f;

    // Start is called before the first frame update
    public override void Start()
    {
        ApplyForce();
        Destroy(gameObject, lifespan);
    }

    // Continuously accelerate downward
    public void Update() {
        _rigidbody.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);
    }
}
