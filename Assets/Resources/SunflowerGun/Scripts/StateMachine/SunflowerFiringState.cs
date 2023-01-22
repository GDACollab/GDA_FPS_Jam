namespace Sunflower
{
    public class FiringState : BaseState
    {
        public FiringState( SunflowerChargeController controller ) : base( controller )
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
    }
}
