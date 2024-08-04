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

    // Start is called before the first frame update
    void Start()
    {
        displayCard = gameObject.GetComponent<Card>();
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
