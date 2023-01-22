namespace Sunflower
{
    public abstract class BaseState
    {
        protected SunflowerChargeController controller;
        protected FormObject formObject;
        protected SunflowerGunAnimator animator;

        public BaseState( SunflowerChargeController controller )
        {
            this.controller = controller;
            formObject = this.controller.formObject;
            animator = this.controller.animator;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
