using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldCardScript : CardScript
{   
    private void OnMouseDown() // If the user plays this card
    {
        OnCardPlayed();
    }
    public override void OnCardPlayed()
    {
        Debug.Log("ForceFieldScript.OnPlay()");
    }
}
