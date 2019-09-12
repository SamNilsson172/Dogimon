using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInParty
{
	public Move move;
	public int currentPp;

	public MoveInParty(Move _move)
	{
		move = _move.GetComponent<Move>();
		currentPp = move.pp;
	}
}
