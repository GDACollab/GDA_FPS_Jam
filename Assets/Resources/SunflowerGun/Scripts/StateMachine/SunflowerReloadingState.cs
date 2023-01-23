namespace Sunflower
{
    public class ReloadingState : BaseState
    {
        public ReloadingState( SunflowerChargeController controller, string name ) : base( controller, name )
        {

        }

        public override void Enter()
        {
            animator.Reload();
        }

        public override void Update()
        {
            if( !FormController.Instance._isReloading )
            {
                controller.CurrentState = controller.idleState;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
