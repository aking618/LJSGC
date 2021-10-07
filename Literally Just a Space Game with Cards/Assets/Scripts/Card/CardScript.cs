using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    public string cardName;
    public string cardDescription;
    public int cardCost;
    public GameObject cardImage;
    public CardType cardType;
    public CardTarget cardTarget;

    public virtual void OnCardPlayed()
    {
        Debug.Log("Card Played");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
