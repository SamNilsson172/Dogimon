using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapAlt : MonoBehaviour
{
    public Fight fight;
    public int index;
    public Button button;
    public Text text;

    private void Update()
    {
        if (fight.playerParty[index] != null)
        {
            text.text = fight.playerParty[index].nickname;
        }
        else
            button.interactable = false;

        if (fight.playerParty[index] != fight.playerDog)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void Swap()
    {
        Debug.Log(index);
        fight.publicState = 3;
        fight.publicP = index;
    }
}
