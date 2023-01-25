namespace Sunflower
{
    public abstract class SunflowerBaseStateMachine
    {
        public SunflowerChargeController controller;

        private BaseState _currentState;
        public BaseState CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                // Debug.Log($"Changing state to {value.name}");
                if( _currentState != null )
                {
                    _currentState.Exit();
                }

                _currentState = value;

                _currentState.Enter();
            }
        }

        public SunflowerBaseStateMachine( SunflowerChargeController controller )
        {
            this.controller = controller;

            SetupStateMachine();
        }

        protected abstract void SetupStateMachine();

        public void Update()
        {
            CurrentState.Update();
        }
    }
}