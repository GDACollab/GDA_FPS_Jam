namespace Sunflower
{
    public abstract class BaseState
    {
        public string name;
        protected SunflowerChargeController controller;
        protected FormObject formObject;
        protected SunflowerGunAnimator animator;

        public BaseState( SunflowerChargeController controller, string name )
        {
            this.name = name;

            this.controller = controller;
            formObject = controller.formObject;
            animator = controller.animator;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
    public abstract class BaseState<StateMachineType> : BaseState where StateMachineType : SunflowerBaseStateMachine
    {
        protected StateMachineType stateMachine;
        
        public BaseState( StateMachineType stateMachine, string name ) : base( stateMachine.controller, name )
        {
            this.stateMachine = stateMachine;
        }
    }
}
