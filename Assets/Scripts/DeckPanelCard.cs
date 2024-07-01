using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DeckPanelCard : NetworkBehaviour
{
    public GameObject cardBack;

    public static List<Card> staticDeck;

    public List<Card> nonstaticDeck;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;


    // Start is called before the first frame update
    void Start()
    {
        // Create a full deck
        staticDeck = new List<Card>(CardDatabase.fullDeckSize);
        CardDatabase.cardList.ForEach((card)=>
        {
            Card card1 = card.Copy();
            staticDeck.Add(card1);
        });
        Shuffle();
        //DEBUG
        nonstaticDeck = staticDeck;
    }

    // Update is called once per frame
    void Update()
    {
        VisualDeck();       
    }

    // visual deck size getting smaller
    private void VisualDeck()
    {
        cardBack.SetActive(true);
        if(staticDeck.Count < CardDatabase.fullDeckSize * 0.8)
        {
            cardInDeck1.SetActive(false);
        }
        if(staticDeck.Count < CardDatabase.fullDeckSize * 0.6)
        {
            cardInDeck2.SetActive(false);
        }
        if(staticDeck.Count < CardDatabase.fullDeckSize * 0.4)
        {
            cardInDeck3.SetActive(false);
        }
        if(staticDeck.Count == 0)
        {
            cardInDeck4.SetActive(false);
        }
    }
    public void Shuffle()
    {
        Card temp;
        int randomIndex;
        for(int i = 0; i < staticDeck.Count; i ++)
        {
            temp = staticDeck[i];
            randomIndex = Random.Range(i, staticDeck.Count);
            staticDeck[i] = staticDeck[randomIndex];
            staticDeck[randomIndex] = temp;
        }
    }

    public void DEBUG()
    {
        string output = "";
        for(int i=0;i<staticDeck.Count; i ++)
        {
            output += staticDeck[i].number + " " + staticDeck[i].sign.ToString() +", ";
        }
        Debug.Log(output);
    }
}
