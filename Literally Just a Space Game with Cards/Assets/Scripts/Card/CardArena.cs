using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArena : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>(); // holds all of the cards in our hand
    public List<GameObject> cardSlots = new List<GameObject>(); // holds and displays the card on the field of play

    // Start is called before the first frame update
    void Start()
    {
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
