using System;
using System.Collections.Generic;
using UnityEngine;

public class Scorepad {
    private const int ArrowsNeeded = 3;
    private const int BowsNeeded = 1;
    private readonly Dictionary<Item.ItemSet, int> sets = new Dictionary<Item.ItemSet, int>();
    private readonly Dictionary<Item.ItemSet, int> setValues = new Dictionary<Item.ItemSet, int>();

    public int Arrows { get; set; }
    public int Bows { get; set; }
    public int RangedValue { get; set; }


    public int GetSetCount (Item.ItemSet set) {
        return sets.ContainsKey(set) ? sets[set] : 0;
    }

    public void IncrementSetCount (Item.ItemSet set) {
        if (sets.ContainsKey(set)) {
            sets[set]++;
        }
        else {
            sets[set] = 1;
        }
//        Debug.Log(set + ": " + sets[set]);
    }

    public int GetSetValue(Item.ItemSet set) {
        return setValues.ContainsKey(set) ? setValues[set] : 0;
    }

    public void IncreaseSetValue (Item.ItemSet set, int value) {
        if (setValues.ContainsKey(set))
        {
            setValues[set] += value;
        }
        else
        {
            setValues[set] = value;
        }
//        Debug.Log(set + " Value: " + setValues[set]);
    }

    public bool CanScoreRanged () {
        return Arrows >= ArrowsNeeded && Bows >= BowsNeeded;
    }

    public void ResetSet (Item.ItemSet set) {
        sets.Remove(set);
        setValues.Remove(set);
    }
}
