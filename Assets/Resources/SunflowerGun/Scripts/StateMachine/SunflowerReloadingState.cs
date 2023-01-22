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
            
        }

        public override void Exit()
        {
            
        }

        public void AnimDone()
        {
            controller.CurrentState = controller.idleState;
        }
    }
}
