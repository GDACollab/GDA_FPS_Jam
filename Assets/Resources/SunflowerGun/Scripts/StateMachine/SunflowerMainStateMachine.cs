using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sunflower
{

    public class SunflowerMainStateMachine : SunflowerBaseStateMachine
    {
        public IdleState idleState;
        public ChargingState chargingState;
        public FiringState firingState;
        public EmptyMagState emptyMagState;
        public ReloadingState reloadingState;

        public SunflowerMainStateMachine( SunflowerChargeController controller ) : base( controller )
        {
            
        }

        protected override void SetupStateMachine()
        {
            idleState = new IdleState( this, "Idle" );
            chargingState = new ChargingState( this, "Charging" );
            firingState = new FiringState( this, "Firing" );
            emptyMagState = new EmptyMagState( this, "Empty Mag" );
            reloadingState = new ReloadingState( this, "Reloading" );

            CurrentState = idleState;
        }
    }

}