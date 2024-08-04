using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public int TurnsPlayed = 0;
    public DeckPanelCard deckPanel;
    public void UpdateTurnsPlayed() {
        TurnsPlayed++;
    }

    public Card DrawCard(){
        Debug.Log(deckPanel);
        Card card = deckPanel.GetCard(0);
        deckPanel.RemoveCard(0);
        return card;
    }

    // Start is called before the first frame update
    void Start()
    {
        deckPanel = new DeckPanelCard();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
