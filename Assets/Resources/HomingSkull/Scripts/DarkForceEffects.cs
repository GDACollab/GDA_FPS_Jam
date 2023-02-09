using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkForceEffects : MonoBehaviour
{
    public Animator anim;
    public FormController formController;


    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        formController = FormController.Instance;

    }

    public void Update()
    {
        anim.SetBool("DarkFire", formController._currentPrimaryIsPressed);

        if (formController._currentSecondaryIsPressed)
        {
            anim.SetBool("DarkFire", true);
        }


    }
}
