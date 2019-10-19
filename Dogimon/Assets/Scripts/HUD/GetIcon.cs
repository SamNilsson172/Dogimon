using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIcon : MonoBehaviour
{
	public Parties parties;
	public Image image;
	public GameObject hpBar;
	public int index;

	// Update is called once per frame
	void Update()
	{
		image.color = Color.clear;
		hpBar.transform.localScale = new Vector2(0, 0);
		if (parties.playerParty[index].dogimon.imgBack != null)
		{
			image.color = Color.white;
			image.sprite = parties.playerParty[index].dogimon.imgFront;
			float scaleX = parties.playerParty[index].CurrentHp / parties.playerParty[index].dogimon.hp;
			hpBar.transform.localScale = new Vector2(scaleX, 0.1f);
		}
	}
}
