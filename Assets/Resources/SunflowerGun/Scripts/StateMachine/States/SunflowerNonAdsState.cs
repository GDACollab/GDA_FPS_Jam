namespace Sunflower
{
    public class NonAdsState : BaseState<SunflowerAdsStateMachine>
    {
        public NonAdsState( SunflowerAdsStateMachine stateMachine, string name ) : base( stateMachine, name )
        {

        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if( FormController.Instance.isADS )
            {
                stateMachine.CurrentState = stateMachine.adsState;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
