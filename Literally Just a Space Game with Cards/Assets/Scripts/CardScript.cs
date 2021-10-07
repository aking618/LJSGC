using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardScript : MonoBehaviour
{

    public string cardName;
    public string cardDescription;
    public int cardCost;
    public GameObject cardImage;
    public CardType cardType;
    public CardTarget cardTarget;

    public abstract void OnCardPlayed();

}
