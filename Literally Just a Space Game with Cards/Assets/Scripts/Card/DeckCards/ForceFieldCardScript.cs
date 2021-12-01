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
        Unit playerUnit = GameObject.Find("Player(Clone)").GetComponent<Unit>();
        playerUnit.Defend();
        playerUnit.currentEnergy -= 1;
        GameObject.Find("PlayerBattleHUD").GetComponent<BattleHUD>().SetHUD(playerUnit); 
        Debug.Log("ForceFieldScript.OnPlay()");
    }
}
