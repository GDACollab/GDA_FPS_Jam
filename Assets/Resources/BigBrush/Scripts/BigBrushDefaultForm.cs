using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Forms/BigBrush_Default Form")]
public class BigBrushDefaultForm : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject _bullet;
    public LayerMask raycastCheckLayers;

    // Offset from forward that each of the side bullets take
    public float leftBulletOffset = -30f;
    public float rightBulletOffset = 30f;

    //FormAction() is called each time the form "shoots".
    public override void FormAction(float context)
    {
        base.FormAction(-1);

        float[] firingOffsets = { leftBulletOffset, 0f, rightBulletOffset };
        foreach (var offset in firingOffsets)
        {
            // Find current rotational offset
            Quaternion rotation = Quaternion.AngleAxis(offset, Camera.main.transform.up);

            //Spawn bullet prefab at weapon's barrel position
            var bullet = Instantiate(_bullet, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
            SpawnedGarbageController.Instance.AddAsChild(bullet);
            RaycastHit info;

            var dir = rotation * PlayerController.Instance._playerCamera.forward;
            bullet.GetComponent<BaseBullet>().SetDirection(dir);

            // Raycast into world from camera position + direction, if target found, set bullet target position to that point, else, bullet direction mimics player camera.
            // This allows us to shoot these projectile bullets from the gun rather than the center of the screen to get the desired appearance
            // If the weapon were hitscan, we could skip this and just add tracers from the gun to the desired destination
            if (Physics.Raycast(Camera.main.transform.position, rotation * Camera.main.transform.forward, out info, 200.0f, raycastCheckLayers))
            {
                var pos = info.point;
                bullet.GetComponent<BaseBullet>().SetTargetPosition(pos);
            }
        }
    }
}