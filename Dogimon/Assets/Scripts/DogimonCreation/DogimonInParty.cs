using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogimonInParty //instance of dogimon with added variables for usability
{
    public Dogimon dogimon { get; }
    public MoveInParty[] moves { get; } = new MoveInParty[4];
    float currentHp;
    public int xp, lvl;
    public string nickname;

    public float CurrentHp
    {
        get => currentHp;
        set
        {
            if (value < 0)
                value = 0;
            if (value > dogimon.hp)
                value = dogimon.hp;
            currentHp = value;
        }
    }

    public DogimonInParty(GameObject _dogimonGo, float _currentHp, int _xp, Move[] _moves)
    {
        dogimon = _dogimonGo.GetComponent<Dogimon>();
        currentHp = _currentHp;
        if (_currentHp == -1)
            currentHp = dogimon.hp;
        xp = _xp;
        nickname = dogimon.name;
        LevelAlgorithm();

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

    public void LevelAlgorithm()
    {
        if (dogimon.fastLvling)
        {
            lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3) * 4f / 5);
        }
        if (dogimon.mediumLvling)
        {
            lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3));
        }
        if (dogimon.slowLvling)
        {
            lvl = Mathf.FloorToInt(Mathf.Pow(xp, 1f / 3) * 5f / 4);
        }
    }

    public float Attack(MoveInParty move)
    {
        float dmg = move.move.dmg + lvl;
        move.CurrentPp--;

        return dmg;
    }

    public void Hurt(float dmg)
    {
        CurrentHp -= dmg / (dogimon.def + (lvl / 10));
    }
}
