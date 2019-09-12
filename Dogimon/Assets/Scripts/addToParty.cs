using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addToParty : MonoBehaviour
{
	//testing
	public DogimonIndex dogimonIndex;
	public Parties parties;
	public Transform playerParty;
	public Transform opponentParty;
	int timesClicked = 0;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && timesClicked < 6)
		{
			int random = Random.Range(1, 4);
			if (random == 1)
				AddToParty(dogimonIndex.dogimonOne, playerParty, parties.playerParty, timesClicked, -1, 1);
			if (random == 2)
				AddToParty(dogimonIndex.dogimonTwo, playerParty, parties.playerParty, timesClicked, -1, 1);
			if (random == 3)
				AddToParty(dogimonIndex.dogimonThree, playerParty, parties.playerParty, timesClicked, -1, 1);
			timesClicked++;
			Debug.Log(timesClicked + ": " + parties.playerParty[timesClicked - 1].dogimon.name + " at lvl " + parties.playerParty[timesClicked - 1].lvl + "!  " + parties.playerParty[timesClicked - 1].moves[0].move.name);
		}
	}
	//testing

	void AddToParty(GameObject dogimonGo, Transform parent, DogimonInParty[] party, int partyIndex, float hp, int xp) //metod for adding dogimons to a party
	{
		GameObject newDogimonGo = Instantiate(dogimonGo); //create new instance of desired dogimon and store it
		newDogimonGo.transform.parent = parent; //set it as child to partys transform

		Dogimon dogimon = newDogimonGo.GetComponent<Dogimon>();
		Move[] moves = new Move[dogimon.learnableMoves.Length];
		int i = 0;
		foreach (GameObject m in dogimon.learnableMoves) //instantite all moves the dog can learn
		{
			//GameObject newMove = Instantiate(m, newDogimonGo.transform.parent);
			moves[i] = m.GetComponent<Move>();
			i++;
		}

		party[partyIndex] = new DogimonInParty(newDogimonGo, hp, xp, moves); //create dogimon and add to party
	}
}
