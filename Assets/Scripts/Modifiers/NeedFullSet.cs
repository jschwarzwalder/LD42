using UnityEngine;

namespace Modifiers {
    public class NeedFullSet : ItemModifier {

        public int SetSize;

        public override int ValueMultiplier {
            get { return 5; }
        }

        public override int GetSetValue (Scorepad scorepad) {
            Item.ItemSet? set = GetComponent<Item>().getSet();
            int value = GetComponent<Item>().Value;
            if (set == null) {
                return SetSize <= 1 ? value : 0;
            }

            if (scorepad == null)
            {
                return 0;
            }

            scorepad.IncrementSetCount(set.Value);
            scorepad.IncreaseSetValue(set.Value, value);

            if (scorepad.GetSetCount(set.Value) < SetSize) {
                return 0;
            }

            int setValue = scorepad.GetSetValue(set.Value);
            scorepad.ResetSet(set.Value);
            return setValue;
        }
    }
}
