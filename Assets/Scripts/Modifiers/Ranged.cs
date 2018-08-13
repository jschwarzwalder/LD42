using UnityEngine;

namespace Modifiers {
    public class Ranged : ItemModifier {

        public enum Type { BOW, ARROW };

        public Type RangedType;

        public override int ValueMultiplier {
            get { return 6; }
        }

        public override int GetSetValue (Scorepad scorepad)
        {
            //if we already have enough bows and arrows, just score it
            if (scorepad == null)
            {
                return 0;
            }

            int itemValue = GetComponent<Item>().Value;
            if (scorepad.CanScoreRanged()) {
                return itemValue;
            }

            //if we don't add this item to the tally
            if (RangedType == Type.ARROW) {
                scorepad.Arrows++;
            }
            else {
                scorepad.Bows++;
            }
            scorepad.RangedValue += itemValue;

            //if we have enough bows and arrows now, score this item along with the previous ones
            if (scorepad.CanScoreRanged()) {
                return scorepad.RangedValue;
            }

            //if we still don't have enough this item has no value
            return 0;
        }
    }
}
