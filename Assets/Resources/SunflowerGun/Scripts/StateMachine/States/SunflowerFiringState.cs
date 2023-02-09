namespace Sunflower
{
    public class FiringState : BaseState<SunflowerMainStateMachine>
    {
        public FiringState( SunflowerMainStateMachine stateMachine, string name ) : base( stateMachine, name )
        {

        }

        public override void Enter()
        {
            animator.Shoot();
        }

        public override void Update()
        {
            if ( FormController.Instance._isReloading )
            {
                stateMachine.CurrentState = stateMachine.reloadingState;
                return;
            }
        }

        public override void Exit()
        {
            
        }

        public void AnimDone()
        {
            if ( FormController.Instance._currentPrimaryIsPressed && formObject._currentPrimaryEnergy != 0 )
            {
                stateMachine.CurrentState = stateMachine.chargingState;
                return;
            }
            else
            {
                stateMachine.CurrentState = stateMachine.idleState;
                return;
            }
        }
    }
}
