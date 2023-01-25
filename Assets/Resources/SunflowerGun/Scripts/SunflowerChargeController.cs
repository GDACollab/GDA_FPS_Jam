using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Sunflower;

public class SunflowerChargeController : MonoBehaviour
{
    // This feels a lot more hardcodey than I'd like it to be, but fuck it this is a game jam lmao
    // -Enrico

    public FormObject formObject;
    [HideInInspector] public SunflowerGunAnimator animator;

    public SunflowerMainStateMachine mainStateMachine;
    public SunflowerAdsStateMachine adsStateMachine;

    private void Awake()
    {
        animator = GetComponent<SunflowerGunAnimator>();

        SetupStateMachines();
    }

    private void SetupStateMachines()
    {
        mainStateMachine = new SunflowerMainStateMachine( this );
        adsStateMachine = new SunflowerAdsStateMachine( this );
    }

    private void Update()
    {
        mainStateMachine.Update();
        adsStateMachine.Update();
    }
}
