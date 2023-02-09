namespace Sunflower
{
    public class ChargingState : BaseState<SunflowerMainStateMachine>
    {
        public ChargingState( SunflowerMainStateMachine stateMachine, string name ) : base( stateMachine, name )
        {

        }

        public override void Enter()
        {
            animator.BeginCharge();

            // TODO: Temporary until an offical fix
            FormController.Instance._currentPrimaryHoldDuration = 0;
        }

        public override void Update()
        {
            if( !FormController.Instance._currentPrimaryIsPressed )
            {
                animator.CancelCharge();

                stateMachine.CurrentState = stateMachine.idleState;
                return;
            }

            if( FormController.Instance.FiredGun )
            {
                stateMachine.CurrentState = stateMachine.firingState;
                return;
            }

            if ( FormController.Instance._isReloading )
            {
                animator.CancelCharge();

                stateMachine.CurrentState = stateMachine.reloadingState;
                return;
            }
        }

        public override void Exit()
        {
            // TODO: Temporary until an offical fix
            FormController.Instance._currentPrimaryHoldDuration = 0;
        }
    }
}
