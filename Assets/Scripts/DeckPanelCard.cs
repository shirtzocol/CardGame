using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DeckPanelCard : NetworkBehaviour
{
    public GameObject cardBack;

    public List<Card> deck;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;


    // Start is called before the first frame update
    void Start()
    {
        // Create a full deck
        deck = new List<Card>(CardDatabase.fullDeckSize);
        CardDatabase.cardList.ForEach((card)=>
        {
            Card cardInDeck = card.Copy();
            deck.Add(cardInDeck);
        });
        Shuffle();
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
        if(deck.Count < CardDatabase.fullDeckSize * 0.8)
        {
            cardInDeck1.SetActive(false);
        }
        if(deck.Count < CardDatabase.fullDeckSize * 0.6)
        {
            cardInDeck2.SetActive(false);
        }
        if(deck.Count < CardDatabase.fullDeckSize * 0.4)
        {
            cardInDeck3.SetActive(false);
        }
        if(deck.Count == 0)
        {
            cardInDeck4.SetActive(false);
        }
    }
    public void Shuffle()
    {
        Card temp;
        int randomIndex;
        for(int i = 0; i < deck.Count; i ++)
        {
            temp = deck[i];
            randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public Card GetCard(int position)
    {
        return deck[position];
    }

    public void RemoveCard(int position)
    {
        deck.RemoveAt(position);
    }

    public void DEBUG()
    {
        string output = "";
        for(int i=0;i<deck.Count; i ++)
        {
            output += deck[i].number + " " + deck[i].sign.ToString() +", ";
        }
        Debug.Log(output);
    }
}
