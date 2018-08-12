using UnityEngine;

namespace Modifiers {
    public class Bottom : ItemModifier
    {
        public override int ValueMultiplier
        {
            get { return 2; }
        }
        
        public override bool CanPlace (ItemSlot slot) {
            return slot.Row == slot.SlotInventory.Rows - 1;
        }
    }
}
