using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDeck : NetworkBehaviour
{
    public PlayerManager playerManager;
    public int x;
    public static List<Card> staticDeck = new List<Card>();
    public List<Card> deck = new List<Card>();

    public GameObject cardToHand;
    public GameObject card;
    public GameObject[] Clones;
    public GameObject Hand;

    public GameObject StartGameButton;
    public static bool newGame;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Start a new Round
        if(TurnSystem.newRound)
        {           
            StartCoroutine(Draw(4));
            TurnSystem.newRound = false;
        }
    }
    public void StartGame()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        playerManager.CmdDealCards();
    }
    
    // Draw X card to player's deck
    IEnumerator Draw(int x)
    {
        // if(x > staticDeck.Count)
        // {
        //     x = staticDeck.Count;
        // }
        // for(int i = 1; i <= x && staticDeck.Count > 0; i++)
        // {
            
        //     yield return new WaitForSeconds(1);
        //     // Create a card and draw it to "Hand" zone
        //     Instantiate(card, Hand.transform);
        // }
        return null;
    }

    
}
