using UnityEngine;

namespace Sunflower
{
    public class SunflowerLoreStateMachine : SunflowerBaseStateMachine
    {
        public LoreOffState loreOffState;
        public LoreOnState loreOnState;
        public GameObject lorePopup;


        public SunflowerLoreStateMachine( SunflowerChargeController controller ) : base( controller )
        {
            
        }

        protected override void SetupStateMachine()
        {
            loreOffState = new LoreOffState(this, "Lore Off");
            loreOnState = new LoreOnState(this, "Lore On");

            CurrentState = loreOffState;
        }
    }

}