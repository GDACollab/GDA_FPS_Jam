namespace Sunflower
{
    public class SunflowerAdsStateMachine : SunflowerBaseStateMachine
    {
        public NonAdsState nonAdsState;
        public AdsState adsState;

        public SunflowerAdsStateMachine( SunflowerChargeController controller ) : base( controller )
        {
            
        }

        protected override void SetupStateMachine()
        {
            nonAdsState = new NonAdsState( this, "Non ADS" );
            adsState = new AdsState( this, "ADS" );

            CurrentState = nonAdsState;
        }
    }

}