using UnityEngine;

namespace Modifiers
{
    public class Sell : ItemModifier
    {

        public override int ValueMultiplier
        {
            get { return 1; }
        }

        public override bool CanReplace(ItemSlot slot)
        {
            return true;
        }

        public override void PerformAction(ItemSlot slot)
        {
            Debug.Log("Sell " + slot.SlotItem.gameObject);
            slot.ScoreItemEarly();
            Destroy(slot.SlotItem.gameObject);
        }
    }
}
