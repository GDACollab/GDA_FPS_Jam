namespace Sunflower
{
    public class IdleState : BaseState
    {
        public IdleState( SunflowerChargeController controller ) : base( controller )
        {

        }
        
        public override void Enter()
        {
            
        }

        public override void Update()
        {
            // If we are reloading
            if ( FormController.Instance._isReloading )
            {
                controller.CurrentState = controller.reloadingState;
                return;
            }

            // If we are ready to shoot
            if( formObject._currentPrimaryEnergy != 0 &&
                formObject._currentPrimaryCooldown <= 0)
            {
                if( FormController.Instance._currentPrimaryIsPressed )
                {
                    controller.CurrentState = controller.chargingState;
                    return;
                }
                else
                {
                    // // We are in the same frame as when we release the button
                    // if (isCharging)
                    // {
                    //     // TODO: Run checks on if we need to cancel charge animation or shoot
                        
                    //     // Need to let the charging sound ring out after firing otherwise it'll sound jarring
                    //     if (formObject._currentPrimaryCooldown <= 0)
                    //     {
                            
                    //     }
                    // }
                }
            }
        }

        public override void Exit()
        {
            
        }
    }
}
