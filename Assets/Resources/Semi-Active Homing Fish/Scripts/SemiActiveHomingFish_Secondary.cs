using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using UnityEngine;

[CreateAssetMenu(menuName = "Forms/SemiActiveHomingFish_Secondary Form")]
public class SemiActiveHomingFish_Secondary : BaseForm
{
    [Header("Form Specific Data")]
    public GameObject _bullet;
    private bool trackerActive;
    private List<Transform> targetable;

    //FormAction() is called each time the form "shoots".
    public override void FormAction(float context)
    {
        base.FormAction(-1);
        //tracker Toggle
        FormController.Instance.currentForm.GetComponent<SemiActiveHomingFishWeaponController>().ToggleTrackerState();
        

    }
}
