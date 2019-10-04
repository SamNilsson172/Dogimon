using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Fight fight;

    // Update is called once per frame
    void FixedUpdate()
    {
        canvasGroup.alpha = (fight.waitTime == 0 && fight.yourAtkTurn) ? 0 : 1; //use your atk turn for no flickering
        canvasGroup.blocksRaycasts = canvasGroup.alpha == 1;
    }
}
