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
            this.controller = controller;
            formObject = this.controller.formObject;
            animator = this.controller.animator;

            this.name = name;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
