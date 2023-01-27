using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sunflower
{
    public class EmptyMagState : BaseState<SunflowerMainStateMachine>
    {
        public EmptyMagState( SunflowerMainStateMachine stateMachine, string name ) : base( stateMachine, name )
        {

        }

        public override void Enter()
        {
            animator.PlayAudio(animator.emptyMagSound, 0.5f);
        }

        public override void Update()
        {
            if ( !FormController.Instance._currentPrimaryIsPressed )
            {
                stateMachine.CurrentState = stateMachine.idleState;
                return;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
