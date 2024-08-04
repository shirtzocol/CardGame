using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
[System.Serializable]

public class Card : NetworkBehaviour {
    
    public enum Sign {Heart, Diamond, Clubs, Spades};

    public int number { get; set; }
    public Sign sign { get; set; }
    public int points { get; set; }
    public Sprite spriteImage { get; set; }

    public Card()
    {

    }
    public Card(int Number, Sign Sign, int Points, Sprite SpriteImage)
    {
        number = Number;
        sign = Sign;
        points = Points;
        spriteImage = SpriteImage;
    }

    public Card Copy()
    {
        return new Card(number, sign, points, spriteImage);
    }
}
