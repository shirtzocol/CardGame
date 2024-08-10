using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Card;
    public GameObject Hand;
    public GameObject HandEnemy;
    public GameObject MainArea;
    public GameObject deck;
    GameManager gm;

    List<GameObject> cards = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();

        MainArea = GameObject.Find("MainArea");
        Hand = GameObject.Find("Hand");
        HandEnemy = GameObject.Find("HandEnemy");

        NetworkServer.Spawn(deck);

    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
    
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        deck = GameObject.Find("DeckPanel");


        
        // TODO - Whats that for?
        cards.Add(Card);
    }

    [Command]
    public void CmdDealCards()
    {
        Debug.Log("Deal Cards");

        if(isServer)
        {
            //DealCards();
        }

        for(int i = 0; i < 4; i++)
        {
            // Create a card and draw it to "Hand" zone
            GameObject card = Instantiate(Card, Hand.transform);
            // Get the right card values from deck
            if(isServer)
            {
                SetCard(card);
            }

            NetworkServer.Spawn(card, connectionToClient);

            RpcShowCard(card, "Dealt");
        }
    }
    [Server]
    void SetCard(GameObject card)
    {
        DeckPanelCard deck1 = deck.GetComponent<DeckPanelCard>();
        Card cardInfo = deck1.GetCard(0);
        Debug.Log("caqrdnumber: " + cardInfo.number);
        deck1.RemoveCard(0);
        Card cardComponent = card.GetComponent<Card>();
        cardComponent = cardInfo;
        // RpcDrawToClients(card, cardInfo);
    }

    [ClientRpc]
    void RpcDrawToClients(GameObject card, Card cardInfo)
    {
        Card cardComponent = card.GetComponent<Card>();
        cardComponent = cardInfo;
    }

    // [Server]
    // void DealCards()
    // {
    //     gm.UpdateTurnsPlayed();
    //     RpcLogToClients("Turns played: " + gm.TurnsPlayed);
    // }

    // [ClientRpc]
    // void RpcLogToClients(string message)
    // {
    //     Debug.Log(message);
    // }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");

        if(isServer)
        {
            UpdateTurnsPlayed();
        }
    }

    [Server]
    void UpdateTurnsPlayed()
    {
        gm.UpdateTurnsPlayed();
        RpcLogToClients("Turns played: " + gm.TurnsPlayed);
    }

    [ClientRpc]
    void RpcLogToClients(string message)
    {
        Debug.Log(message);
    }


    [ClientRpc]
    void RpcShowCard(GameObject card, string name)
    {
        if(name == "Dealt")
        {
            deck.GetComponent<DeckPanelCard>().cardInDeck1.SetActive(false);

            if(isOwned)
            {
                card.transform.SetParent(Hand.transform, false);
            }
            else
            {
                card.transform.SetParent(HandEnemy.transform, false);
                card.GetComponent<DisplayCard>().Flip();
            }
        }
        else if(name == "Played")
        {
            card.transform.SetParent(MainArea.transform, false);
            
            // Show enemy card when is played
            if(!isOwned)
            {
                card.GetComponent<DisplayCard>().Flip();
            }
        }
    }

}
