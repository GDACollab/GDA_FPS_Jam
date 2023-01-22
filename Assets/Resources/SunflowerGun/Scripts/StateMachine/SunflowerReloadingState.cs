namespace Sunflower
{
    public class ReloadingState : BaseState
    {
        public ReloadingState( SunflowerChargeController controller ) : base( controller )
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
    }
}
