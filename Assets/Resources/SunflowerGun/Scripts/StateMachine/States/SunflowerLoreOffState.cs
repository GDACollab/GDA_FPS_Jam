namespace Sunflower
{
    public class LoreOffState : BaseState<SunflowerLoreStateMachine>
    {
        public LoreOffState( SunflowerLoreStateMachine stateMachine, string name ) : base( stateMachine, name )
        {
            stateMachine.lorePopup = animator.SpawnLorePopup();
            stateMachine.lorePopup.SetActive(false);
        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if( FormController.Instance._currentSecondaryIsPressed )
            {
                stateMachine.CurrentState = stateMachine.loreOnState;
            }
        }

        public override void Exit()
        {
            
        }
    }
}
