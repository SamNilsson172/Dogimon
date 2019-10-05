using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public Fight fight;
    float preHp;
    int preDog = 6; //ooc
    float percentage = 0;
    float damage = 0;

    private void FixedUpdate()
    {
        if (transform.localScale.x - (fight.playerDog.currentHp / fight.playerDog.dogimon.hp) < -.1f && transform.localScale.x - (fight.playerDog.currentHp / fight.playerDog.dogimon.hp) > .1f)
        {
            damage = preHp - fight.playerDog.currentHp;
            percentage = damage / fight.playerDog.dogimon.hp;
        }

        if (damage > 0.1f || damage < -0.1f && preDog == fight.p)
        {
            Debug.Log(damage);
            transform.localScale = new Vector3(transform.localScale.x - percentage / 50, 1);
            damage -= damage / 50f;
        }
        else
        {
            Debug.Log("bye");
            transform.localScale = new Vector2(fight.playerDog.currentHp / fight.playerDog.dogimon.hp, 1);
            preHp = fight.playerDog.currentHp;
            preDog = fight.p;
        }
    }
}
