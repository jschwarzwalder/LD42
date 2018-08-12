using UnityEngine;

namespace Modifiers
{
    public class Side : ItemModifier
    {
        public override int ValueMultiplier
        {
            get { return 2; }
        }

        public override bool CanPlace(ItemSlot slot) {
            return slot.Column == 0 || slot.Column == slot.SlotInventory.Columns - 1;
        }
    }
}
