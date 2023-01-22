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

    private BaseState _currentState;
    public BaseState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            if( _currentState != null )
            {
                _currentState.Exit();
            }

            _currentState = value;

            _currentState.Enter();
        }
    }

    public IdleState idleState;
    public ChargingState chargingState;
    public FiringState firingState;
    public ReloadingState reloadingState;

    private void Awake()
    {
        animator = GetComponent<SunflowerGunAnimator>();

        SetupStateMachine();
    }

    private void SetupStateMachine()
    {
        idleState = new IdleState( this );
        chargingState = new ChargingState( this );
        firingState = new FiringState( this );
        reloadingState = new ReloadingState( this );

        CurrentState = idleState;
    }

    private void Update()
    {
        CurrentState.Update();
    }
}
