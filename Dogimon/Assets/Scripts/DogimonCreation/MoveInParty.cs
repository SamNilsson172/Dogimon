using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInParty
{
    public Move move { get; }
    int currentPp;
    public int CurrentPp
    {
        get => currentPp;
        set
        {
            if (value > move.pp)
                value = move.pp;
            if (value < 0)
                value = 0;
            currentPp = value;
        }
    }

    public MoveInParty(Move _move)
    {
        move = _move.GetComponent<Move>();
        currentPp = move.pp;
    }
}
