using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArena : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>(); // holds all of the cards in our hand
    public List<GameObject> cardSlots = new List<GameObject>(); // holds and displays the card on the field of play

    public List<GameObject> Deck = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Generate Cards in Hand randomly from Deck of Cards
        for(int i = 0; i < cardSlots.Count; i++) // We only hold the number of card slots that exist in our hand
        {
            int cardInDeck = Random.Range(0, Deck.Count - 1);
            hand.Add(Deck[cardInDeck]);
        }

        int slotIndex = 0;
        foreach(GameObject card in hand) // goto the next card in our hand
        {
            // Get the position of the next card slot
            Vector3 vec = cardSlots[slotIndex].transform.position;
            Instantiate(card, vec, Quaternion.identity); // instantiate the card at that card slots position
            slotIndex++; // goto the next card slot
        }

        //Instantiate(cardGO, gameObject.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
