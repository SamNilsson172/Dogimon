using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDogVisuals : MonoBehaviour
{
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
    void UpdateCheck()
    {
        //check everything besides hpBar and XpBar
    }
}
