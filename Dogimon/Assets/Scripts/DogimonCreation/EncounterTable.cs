using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTable : MonoBehaviour
{
    public enum DogNumber { Null, Corgi, Bulldog, Labrador,BorderCollie,GermanShepard,OldEnglishSheepDog } //number in string(text)
    public enum EncountNum { test = 1 }

    public bool fighting;

    public DogimonIndex dogimonIndex;
    public Transform playerParty;
    public Transform opponentParty;
    public Parties parties;

    void AddToParty(GameObject dogimonGo, Transform parent, DogimonInParty[] party, int partyIndex, float hp, int xp) //metod for adding dogimons to a party
    {
        GameObject newDogimonGo = Instantiate(dogimonGo); //create new instance of desired dogimon and store it
        newDogimonGo.transform.parent = parent; //set it as child to partys transform

        Dogimon dogimon = newDogimonGo.GetComponent<Dogimon>();
        Move[] moves = new Move[dogimon.learnableMoves.Length];
        int i = 0;
        foreach (GameObject m in dogimon.learnableMoves) //instantite all moves the dog can learn
        {
            moves[i] = m.GetComponent<Move>();
            i++;
        }

        party[partyIndex] = new DogimonInParty(newDogimonGo, hp, xp, moves); //create dogimon and add to party
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Opponent")
        {
            OpponentsEncounterNum opponentsEncounterNum = collision.GetComponent<OpponentsEncounterNum>();

            if (opponentsEncounterNum.num == (int)EncountNum.test)
                AddToParty(dogimonIndex.dogimons[(int)DogNumber.Corgi], opponentParty, parties.opponentParty, 0, -1, 5);
            Debug.Log(parties.opponentParty[0].nickname);
        }
    }
}
