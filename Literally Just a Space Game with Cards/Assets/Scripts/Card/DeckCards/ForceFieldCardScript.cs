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

        if (!IsPlayerTurn(GameObject.Find("Battle System").GetComponent<BattleSystem>().state))
        {
            return;
        }

        if (playerUnit.isDefending)
        {
            StartCoroutine(UpdateUI("Force Field is already active!"));
            return;
        }

        if (playerUnit.currentEnergy < 1)
        {
            StartCoroutine(UpdateUI("Not enough energy!"));
            return;
        }

        PlayAudio();

        playerUnit.Defend();
        playerUnit.UseEnergy(1);

        StartCoroutine(UpdateUI("Force Field activated!"));

        GameObject.Find("PlayerBattleHUD").GetComponent<BattleHUD>().SetHP(playerUnit.currentHP);
        GameObject.Find("PlayerBattleHUD").GetComponent<BattleHUD>().SetHUD(playerUnit);

        Debug.Log("ForceFieldScript.OnPlay()");
    }
}
