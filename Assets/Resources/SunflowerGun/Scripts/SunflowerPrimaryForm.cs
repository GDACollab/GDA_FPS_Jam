using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Forms/Sunflower Primary Form")]
public class SunflowerPrimaryForm : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject projectile;
    public LayerMask raycastCheckLayers;


    public override void FormAction(float context)
    {
        //Spawn bullet prefab at weapon's barrel position
        GameObject bullet = Instantiate(projectile, FormController.Instance.currentForm.barrelSpawn.position, Quaternion.identity);
        SpawnedGarbageController.Instance.AddAsChild(bullet);
        
        bullet.GetComponent<BaseHitscan>().SetTargetDirection(Camera.main.transform.forward);
    }
}
