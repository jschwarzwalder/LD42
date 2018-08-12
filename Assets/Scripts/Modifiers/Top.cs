namespace Modifiers {
    public class Top : ItemModifier
    {

        public override int ValueMultiplier
        {
            get { return 2; }
        }

        public override bool CanPlace(ItemSlot slot)
        {
            return slot.Row == 0;
        }
    }
}

