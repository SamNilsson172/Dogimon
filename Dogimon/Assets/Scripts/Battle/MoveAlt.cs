using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlt : MonoBehaviour
{
    public int index;
    Fight fight;
    // Start is called before the first frame update
    void Start()
    {
        fight = GameObject.Find("BattleScene").GetComponent<Fight>();
    }

    public void ChooseMove() 
    {
        fight.publicA = index; //set move to the one clicked
        fight.publicState = 1; //run attack method
    }
}
