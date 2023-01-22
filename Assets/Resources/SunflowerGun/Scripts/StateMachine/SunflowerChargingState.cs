namespace Sunflower
{
    public class ChargingState : BaseState
    {
        public ChargingState( SunflowerChargeController controller ) : base( controller )
        {

        }

        public override void Enter()
        {
            animator.BeginCharge();
        }

        public override void Update()
        {
            if( !FormController.Instance._currentPrimaryIsPressed )
            {
                animator.CancelCharge();

                controller.CurrentState = controller.idleState;
                return;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
