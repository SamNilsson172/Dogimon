using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAlt : MonoBehaviour
{
    public int index;
    public Text text;
    public Button button;
    public Fight fight;

    private void Update()
    {
        if (fight.playerDog != null)
        {
            if (fight.playerDog.moves[index] != null)
            {
                text.text = fight.playerDog.moves[index].move.name;
                button.interactable = true;
            }
            else
                button.interactable = false;
        }
    }

    public void ChooseMove()
    {
        fight.publicA = index; //set move to the one clicked
        fight.publicState = 1; //run attack method
    }
}
