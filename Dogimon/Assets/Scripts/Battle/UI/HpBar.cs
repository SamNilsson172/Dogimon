using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public Fight fight;
    public bool player; //if players hp bar or opponents
    float preHp; //to remember hp before dmg was inflicted
    int preDog = 6; //remember index of last dog in party to know if it was changed, ooc in start for slide = false

    private void Update()
    {
        if (player) //contains specific values for player
        {
            float damage = preHp - fight.playerDog.CurrentHp; //check diffrence in hp between runtimes
            if (damage != 0) //if dmg has been inflicted
            {
                bool slide = preDog == fight.publicP; //true if dog has not been changed, determies if hp bar playes animation or not
                StartCoroutine(HpScaleChange(fight.playerDog.dogimon.hp, preHp, damage, fight.playerDog.CurrentHp, slide)); //change the hp bar
            }
            preHp = fight.playerDog.CurrentHp; //set pre hp at end for next runtime
            preDog = fight.publicP; // set pre dog at end for next runtime
        }
        if (!player) //contains specific values for opponent, same as above
        {
            float damage = preHp - fight.opponentDog.CurrentHp;
            if (damage != 0)
            {
                bool slide = preDog == fight.publicO;
                StartCoroutine(HpScaleChange(fight.opponentDog.dogimon.hp, preHp, damage, fight.opponentDog.CurrentHp, slide));
            }
            preHp = fight.opponentDog.CurrentHp;
            preDog = fight.publicO;
        }
    }

    IEnumerator HpScaleChange(float maxHp, float preHp, float damage, float currentHp, bool slide) //changes the x scale on hp bar to desired value
    {
        if (damage > preHp)
            damage = preHp;

        if (slide) //if the hp should slide or not
            for (int i = 0; i < 50; i++) //loop 50 times and make scale smaller each one
            {
                float currentDmg = i * damage / 50; //how much smaller to make it this runtime
                transform.localScale = new Vector2((preHp - currentDmg) / maxHp, 1); //set the scale
                yield return new WaitForSeconds(.02f); //wait total 1 sec
            }
        transform.localScale = new Vector2(currentHp / maxHp, 1); //set hp scale with values only from the dog that hasn't been mathified, also for no animation
    }
}
