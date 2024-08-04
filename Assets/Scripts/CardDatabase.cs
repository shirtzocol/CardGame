using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    public static int fullDeckSize = 52;

    void Awake()
    {
        int points;
        for(int i = 1; i <= 13; i ++)
        {
            foreach(Card.Sign sign in Enum.GetValues(typeof(Card.Sign)))
            {
                points = 0;
                if (i == 1 || i == 11)
                {
                    points = 1;
                }
                if (i == 2 && sign == Card.Sign.Clubs)
                {
                    points = 2;
                }
                if (i == 10 && sign == Card.Sign.Diamond)
                {
                    points = 3;
                }
                cardList.Add(new Card(i, sign, points, Resources.Load<Sprite>(sign.ToString())));
            }
        }
    }
}
