using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogimon : MonoBehaviour //class for all dogimons, applyed to prefabs
{
	public Sprite imgFront, imgBack; //what they look like
	public float atk, def, spe, hp; //their stats
	public new string name; //their name
	public int number; //number to look for it
	public GameObject[] learnableMoves = new GameObject[0];
	public bool fastLvling, mediumLvling, slowLvling;
	public int LevelAlgorithm(int xp)
	{
		int lvl = 0;
		if (fastLvling)
		{
			lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3) * 4f / 5);
		}
		if (mediumLvling)
		{
			lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3));
		}
		if (slowLvling)
		{
			lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3) * 5f / 4);
		}
		return lvl;
	}
}
