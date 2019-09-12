using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAlt : MonoBehaviour
{
    public Fight fight;
    public int index;

    public void Swap()
    {
        fight.publicState = 3;
        fight.publicP = index;
    }
}
