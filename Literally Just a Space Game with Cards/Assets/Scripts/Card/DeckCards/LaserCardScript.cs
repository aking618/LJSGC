using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCardScript : CardScript
{
    private void OnMouseDown() // if the user plays this card
    {
        OnCardPlayed();
    }
    public override void OnCardPlayed()
    {

        Unit enemyUnit = GameObject.Find("Enemy(Clone)").GetComponent<Unit>();
        Unit playerUnit = GameObject.Find("Player(Clone)").GetComponent<Unit>();
        BattleSystem battleSystem = GameObject.Find("Battle System").GetComponent<BattleSystem>();

        if (!IsPlayerTurn(battleSystem.state))
        {
            return;
        }

        if (playerUnit.currentEnergy < 2)
        {
            StartCoroutine(UpdateUI("Not enough energy!"));
            return;
        }

        PlayAudio();

        playerUnit.UseEnergy(2);

        if (enemyUnit.TakeDamage(6))
        {
            StartCoroutine(HandleWin());
        }

        StartCoroutine(UpdateUI("Direct Hit for 6 damage!"));

        GameObject.Find("PlayerBattleHUD").GetComponent<BattleHUD>().SetHP(playerUnit.currentHP);

        GameObject.Find("PlayerBattleHUD").GetComponent<BattleHUD>().SetHUD(playerUnit);
        GameObject.Find("EnemyBattleHUD").GetComponent<BattleHUD>().SetHUD(enemyUnit);

        Debug.Log("LaserCardScript.OnPlay()");
    }

}
