namespace Sunflower
{
    public class AdsState : BaseState<SunflowerAdsStateMachine>
    {
        public AdsState( SunflowerAdsStateMachine stateMachine, string name ) : base( stateMachine, name )
        {
            
        }

        public override void Enter()
        {
            animator.TurnOnADS();
        }

        public override void Update()
        {
            if( !FormController.Instance.isADS )
            {
                stateMachine.CurrentState = stateMachine.nonAdsState;
            }
        }

        public override void Exit()
        {
            animator.TurnOffADS();
        }
    }
}
