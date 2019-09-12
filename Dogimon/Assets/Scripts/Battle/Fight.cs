using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public enum State { wait, atk, bag, swap, run, check }

    public EncounterTable encounterTable;
    public Parties parties;
    public UpdateDogVisuals updateDog;

    public int publicState;
    int state; //only changes in and to wait
    public int publicP, publicO, publicA;
    int p, o, a; //active attack / dog in player and opponent party
    public float timer, waitTime;
    bool yourAtkTurn = true;
    DogimonInParty[] playerParty, opponentParty; //less messy code
    public DogimonInParty playerDog, opponentDog;


    // Start is called before the first frame update
    void Start()
    {
        playerParty = parties.playerParty;
        opponentParty = parties.opponentParty;
        //Check();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (encounterTable.fighting)
        {
            //set alpha in BattleCanvas to 1f
            Rules();

            if (Input.GetKeyDown(KeyCode.C)) //run on start
            {
                Check();
            }

            switch (state)
            {
                case (int)State.wait:
                    Wait();
                    break;

                case (int)State.atk:
                    Atk();
                    break;

                case (int)State.bag:
                    Bag();
                    EndNoneAtkState();
                    break;

                case (int)State.swap:
                    Swap();
                    EndNoneAtkState();
                    break;

                case (int)State.run:
                    Run();
                    EndNoneAtkState();
                    break;

                case (int)State.check:
                    Check();
                    state = (int)State.wait;
                    break;
            }
        }
    }

    void Rules()
    {
        //currentHp canot be bigger than hp or smaller than 0, currentPp cannot be bigger than pp or smaller than 0
    }

    void Wait()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            Debug.Log("waited");
            waitTime = 0;
            timer = 0;
            state = publicState;
            a = publicA;
            o = publicO;
            p = publicP;

            //if waittime > 0 , alpha nad others in buttons = 0 and load text
        }
    }

    void Check()
    {
        Debug.Log("check");
        p = ActiveDog(p, playerParty);
        o = ActiveDog(o, opponentParty);
        if (p == 6)
        {
            End();
        }
        if (o == 6)
        {
            End();
        }
        playerDog = playerParty[p];
        opponentDog = opponentParty[o];
        updateDog.UpdateCheck();
    }

    int ActiveDog(int a, DogimonInParty[] party)
    {
        for (int i = 0; i < 6; i++) //loop for entire party
        {
            if (party[a].currentHp > 0) //return a when found a dog with hp
                return a;
            else
            {
                //call xp gain
                a += 1;
            }

            if (a == 6) //if out of index, set to 0
                a = 0;
        }
        return 6; //only returns this if all have 0 hp
    }

    void Bag()
    {

    }

    void Swap()
    {
        Check();
        Debug.Log("swap to " + playerDog.nickname);
        waitTime = 1f;
    }

    void Run()
    {
        int random = Random.Range(1, 51);
        int lvlDifference = playerDog.lvl - opponentDog.lvl;
        if (random + lvlDifference > 20)
            End();
    }

    void Atk()
    {
        Debug.Log("atking");
        MoveInParty usingMove; //less messy code
        DogimonInParty attacker, defender;
        if (yourAtkTurn)
        {
            usingMove = playerDog.moves[a];
            attacker = playerDog;
            defender = opponentDog;
        }
        if (!yourAtkTurn)
        {
            usingMove = opponentDog.moves[a];
            attacker = opponentDog;
            defender = playerDog;
        }

        //imagine code
        //do atk script

        //when all waiting is done and atk is over
        yourAtkTurn = !yourAtkTurn;
        if (!yourAtkTurn) //it will be the opponents turn, go to atk
        {
            state = (int)State.check;
            publicState = (int)State.atk;
        }
        if (yourAtkTurn) //it will be the players turn, go to wait
        {
            state = (int)State.check;
            publicState = (int)State.wait;
        }
        waitTime = 1;
    }

    void EndNoneAtkState()
    {
        state = (int)State.wait;
        publicState = (int)State.atk;
        yourAtkTurn = false;
    }

    void End()
    {
        parties.opponentParty = parties.Clear();
        Destroy(gameObject);
    }
}
