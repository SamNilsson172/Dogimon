using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDogVisuals : MonoBehaviour
{
    public Fight fight;
    public Image playerDog;
    public Image opponentDog;
    public Image playerHpBar;
    public Image opponentHpBar;
    public Image[] opponentDogAmount = new Image[6];
    public Image xpBar;

    public Text playerNameAndLvl;
    public Text opponentNameAndLvl;
    public Text playerHp;
    public Text OpponentHp;

    void Start()
    {
        //do opponent dog amount here
    }

    // Update is called once per frame
    public void UpdateCheck()
    {
        //check everything besides hpBar and XpBar
        playerDog.sprite = fight.playerDog.dogimon.imgBack;
        opponentDog.sprite = fight.opponentDog.dogimon.imgFront;
        playerNameAndLvl.text = fight.playerDog.nickname + " Lvl. " + fight.playerDog.lvl;
        opponentNameAndLvl.text = fight.opponentDog.nickname + " Lvl. " + fight.opponentDog.lvl;
        playerHp.text = Mathf.Ceil(fight.playerDog.currentHp) + " / " + fight.playerDog.dogimon.hp;
        OpponentHp.text = Mathf.Ceil(fight.opponentDog.currentHp) + " / " + fight.opponentDog.dogimon.hp;
    }

    public IEnumerator BarAnimation(bool playerHp, bool xp, float max, float current, float modifier)
    {
        Image bar = null;
        if (playerHp)
            bar = playerHpBar;
        if (!playerHp)
            bar = opponentHpBar;
        if (xp)
            bar = xpBar;

        for (float f = 0; f != 1; f += 0.025f)
        {
            bar.transform.localScale = new Vector2((current - modifier * f) / max, 1);
            yield return new WaitForSeconds(0.025f); //once every 40th sec
        }
    }
}
