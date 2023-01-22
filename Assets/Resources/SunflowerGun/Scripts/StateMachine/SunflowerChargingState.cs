namespace Sunflower
{
    public class ChargingState : BaseState
    {
        public ChargingState( SunflowerChargeController controller, string name ) : base( controller, name )
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

                controller.CurrentState = controller.idleState;
                return;
            }

            if( FormController.Instance.FiredGun )
            {
                controller.CurrentState = controller.firingState;
                return;
            }

            if ( FormController.Instance._isReloading )
            {
                animator.CancelCharge();

                controller.CurrentState = controller.reloadingState;
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
