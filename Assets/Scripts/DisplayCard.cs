using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class DisplayCard : MonoBehaviour
{
    public Card displayCard;

    public Text numberText;
    public Image artImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;
    // Start is called before the first frame update
    void Start()
    {
        displayCard = DeckPanelCard.staticDeck[0];
        DeckPanelCard.staticDeck.RemoveAt(0);
        Debug.Log("Starting Card: " + displayCard.number + " " + displayCard.sign);
    }

    // Update is called once per frame
    void Update()
    {
        // Display Card
        numberText.text = "  " + displayCard.number;
        artImage.sprite = displayCard.spriteImage;

        // Assure card back state
        staticCardBack = cardBack;
    }

    public void Flip()
    {
        cardBack = !cardBack;
    }
}
