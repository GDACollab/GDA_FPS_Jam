namespace Sunflower
{
    public class ReloadingState : BaseState<SunflowerMainStateMachine>
    {
        public ReloadingState( SunflowerMainStateMachine stateMachine, string name ) : base( stateMachine, name )
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
                stateMachine.CurrentState = stateMachine.idleState;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
