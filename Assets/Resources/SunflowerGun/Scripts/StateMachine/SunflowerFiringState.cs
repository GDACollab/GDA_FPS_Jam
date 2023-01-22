namespace Sunflower
{
    public class FiringState : BaseState
    {
        public FiringState( SunflowerChargeController controller, string name ) : base( controller, name )
        {

        }

        public override void Enter()
        {
            animator.Shoot();
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
