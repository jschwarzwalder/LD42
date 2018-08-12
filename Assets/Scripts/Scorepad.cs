using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scorepad {
    private const int ArrowsNeeded = 3;
    private const int BowsNeeded = 1;

    public int Arrows { get; set; }
    public int Bows { get; set; }
    public int RangedValue { get; set; }

    public bool CanScoreRanged () {
        return Arrows >= ArrowsNeeded && Bows >= BowsNeeded;
    }
}
