using UnityEngine;

namespace Sunflower
{
    public class LoreOnState : BaseState<SunflowerLoreStateMachine>
    {
        public LoreOnState( SunflowerLoreStateMachine stateMachine, string name ) : base( stateMachine, name )
        {

        }

        public override void Enter()
        {
            stateMachine.lorePopup.SetActive(true);
        }

        public override void Update()
        {
            if( !FormController.Instance._currentSecondaryIsPressed )
            {
                stateMachine.CurrentState = stateMachine.loreOffState;
            }
        }

        public override void Exit()
        {
            stateMachine.lorePopup.SetActive(false);
        }
    }
}
