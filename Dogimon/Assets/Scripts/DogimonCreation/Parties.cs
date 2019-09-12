using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parties : MonoBehaviour
{
    public GameObject dogimonNull; //needed for no nullrefecxp

    public DogimonInParty[] playerParty = new DogimonInParty[6]; //create parties as arrays for player and opponent
    public DogimonInParty[] opponentParty = new DogimonInParty[6];
    void Awake() //set parties to nothing
    {
        playerParty = Clear();
        opponentParty = Clear();
    }

    public DogimonInParty[] Clear()
    {
        DogimonInParty[] clearParty = new DogimonInParty[6];
        for (int i = 0; i < 6; i++)
            clearParty[i] = new DogimonInParty(dogimonNull, 0, 0, null);
        return clearParty;
    }
}
