using UnityEngine;

namespace Modifiers {
    public class Replace : ItemModifier
    {
        
        public override int ValueMultiplier
        {
            get { return 1; }
        }

        public override bool CanReplace (ItemSlot slot) {
            return true;
        }

        public override void PerformAction (ItemSlot slot) {
            if (slot.SlotItem == null) return;
            Debug.Log("Destroy " + slot.SlotItem.gameObject);
            Destroy(slot.SlotItem.gameObject);
        }
    }
}
