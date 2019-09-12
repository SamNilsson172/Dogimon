using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogimonInParty //instance of dogimon with added variables for usability
{
	public Dogimon dogimon;
	public MoveInParty[] moves = new MoveInParty[4];
	public float currentHp;
	public int xp, lvl;
	public string nickname;

	public DogimonInParty(GameObject _dogimonGo, float _currentHp, int _xp, Move[] _moves)
	{
		dogimon = _dogimonGo.GetComponent<Dogimon>();
		currentHp = _currentHp;
		if (_currentHp == -1)
			currentHp = dogimon.hp;
		xp = _xp;
		nickname = dogimon.name;
		lvl = dogimon.LevelAlgorithm(xp);

		int x = 0;
		if (_moves != null)
			for (int i = _moves.Length - 1; i > -1 /*|| x < 4*/; i--) //get the last four learnable moves
			{
				if (_moves[i].levelLearned <= lvl)
				{
					moves[x] = new MoveInParty(_moves[i]);
					x++;
				}
			}
	}
}
