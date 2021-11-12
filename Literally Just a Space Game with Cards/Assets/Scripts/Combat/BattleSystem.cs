using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    private float textWaitTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Battle Setup");

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " appeared!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(textWaitTime);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("Player Attacking");

        // check if player has enough energy to attack
        if (playerUnit.currentEnergy < playerUnit.attackCost)
        {
            dialogueText.text = "Not enough energy!";
            yield return new WaitForSeconds(textWaitTime);
            dialogueText.text = "Choose an action:";
            yield break;
        }

        playerUnit.UseEnergy(playerUnit.attackCost);
        playerHUD.UpdateEnergy(playerUnit);

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(textWaitTime);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }

        PlayerTurn();
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy Turn");
        dialogueText.text = enemyUnit.unitName + " turn!";

        yield return new WaitForSeconds(textWaitTime);

        switch (enemyUnit.enemyAI)
        {
            case EnemyAI.NONE:
            case EnemyAI.LOW:
                PerformLowAI();
                break;
            case EnemyAI.MEDIUM:
                PerformMediumAI();
                break;
            case EnemyAI.HIGH:
                PerformHighAI();
                break;
            case EnemyAI.BOSS:
                // implmenet custom AI in enemy class
                break;
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        Debug.Log("Player Turn");
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnDefendButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerDefend());
    }

    public void OnEndTurnButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        state = BattleState.ENEMYTURN;

        playerUnit.ResetEnergy();
        playerHUD.UpdateEnergy(playerUnit);

        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDefend()
    {
        Debug.Log("Player Defending");

        dialogueText.text = "You are defending!";
        yield return new WaitForSeconds(textWaitTime);

        // perform defend action
        playerUnit.Defend();

        state = BattleState.ENEMYTURN;

        StartCoroutine(EnemyTurn());
    }


    void PerformLowAI()
    {
        if (enemyUnit.BelowQuarterHP())
        {
            StartCoroutine(EnemyHeal());
            return;
        }

        StartCoroutine(EnemyAttack());
    }

    void PerformMediumAI()
    {
        bool buffActive = true;
        if (!buffActive)
        {
            StartCoroutine(EnemyBuff());
            buffActive = true;
            return;
        }
        else if (enemyUnit.BelowQuarterHP())
        {
            StartCoroutine(EnemyHeal());
            return;
        }

        int choice = Random.Range(0, 3);
        if (choice < 3)
        {
            StartCoroutine(EnemyAttack());
            return;
        }
        else
        {
            StartCoroutine(EnemyDefend());
            return;
        }
    }

    void PerformHighAI()
    {
        bool buffActive = true;
        bool debuffActive = true;
        if (!buffActive)
        {
            StartCoroutine(EnemyBuff());
            buffActive = true;
            return;
        }
        else if (!debuffActive)
        {
            StartCoroutine(EnemyDebuff());
            debuffActive = true;
            return;
        }

        PerformMediumAI();
    }

    IEnumerator EnemyHeal()
    {
        Debug.Log("Enemy Heal");
        dialogueText.text = enemyUnit.unitName + " heals!";
        yield return new WaitForSeconds(textWaitTime);

        enemyUnit.Heal(enemyUnit.defense);
        enemyHUD.SetHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(textWaitTime);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator EnemyAttack()
    {
        Debug.Log("Enemy Attack");
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(textWaitTime);

        // perform attack logic
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(textWaitTime);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EnemyDefend()
    {
        Debug.Log("Enemy Defend");
        dialogueText.text = enemyUnit.unitName + " defends!";
        yield return new WaitForSeconds(textWaitTime);

        // perform defend logic
        enemyUnit.Defend();

        PlayerTurn();
    }

    IEnumerator EnemyBuff()
    {
        Debug.Log("Enemy Buff");
        dialogueText.text = enemyUnit.unitName + " buffs!";
        yield return new WaitForSeconds(textWaitTime);

        // perform buff logic

        PlayerTurn();
    }

    IEnumerator EnemyDebuff()
    {
        Debug.Log("Enemy Debuff");
        dialogueText.text = enemyUnit.unitName + " debuffs!";
        yield return new WaitForSeconds(textWaitTime);

        // perform debuff logic

        PlayerTurn();
    }
}
