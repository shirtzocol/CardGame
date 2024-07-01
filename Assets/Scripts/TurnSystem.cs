using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int opponentTurn;
    public Text turnText;
    public const int maxMana = 4;

    public int currentMana;
    public Text manaText;
    public static bool newRound;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        opponentTurn = 0;

        currentMana = 1;

        newRound = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Turn Text
        if(isYourTurn)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }
        // Update Mana Text
        manaText.text = currentMana+"/"+maxMana;

        // Check if its the end of the current round
        if(currentMana == maxMana)
        {
            newRound = true;
            currentMana = 1;
        }
    }
   
    public void EndYourTurn()
    {
        isYourTurn = false;
        opponentTurn += 1;
    }
    public void EndOpponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
        currentMana +=1;
    }
}
