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


    List<GameObject> cards = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();

        MainArea = GameObject.Find("MainArea");
        Hand = GameObject.Find("Hand");
        HandEnemy = GameObject.Find("HandEnemy");

    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
    
        deck = GameObject.Find("DeckPanel");
        NetworkServer.Spawn(deck);
        
        // TODO - Whats that for?
        cards.Add(Card);
    }

    [Command]
    public void CmdDealCards()
    {
        Debug.Log("Deal Cards");

        for(int i = 0; i < 4; i++)
        {
            // Create a card and draw it to "Hand" zone
            GameObject card = Instantiate(Card, Hand.transform);
            Debug.Log("Server");
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }
    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string name)
    {
        if(name == "Dealt")
        {
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
