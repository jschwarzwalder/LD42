using UnityEngine;

namespace Modifiers {
    public class SetBonus : ItemModifier {

        public int SetSize;
        public int SetMultiplier;

        public override int ValueMultiplier {
            get { return 2; }
        }

        public override int GetSetValue (Scorepad scorepad) {
            Item.ItemSet? set = GetComponent<Item>().getSet();
            int value = GetComponent<Item>().Value;
            if (set == null) {
                return SetSize <= 1 ? value * SetMultiplier : value;
            }

            if (scorepad == null)
            {
                return 0;
            }

            scorepad.IncrementSetCount(set.Value);
            scorepad.IncreaseSetValue(set.Value, value);

            if (scorepad.GetSetCount(set.Value) < SetSize) {
                return value;
            }

            int setValue = scorepad.GetSetValue(set.Value);
            scorepad.ResetSet(set.Value);
            return setValue + value;
        }
    }
}
