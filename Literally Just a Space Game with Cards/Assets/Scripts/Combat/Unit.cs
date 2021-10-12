using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    PLAYER,
    ENEMY
}

public enum EnemyAI
{
    NONE, // No AI (player controlled)
    LOW, // LVL 1 - 31
    MEDIUM, // LVL 32 - 49
    HIGH, // LVL 50 - 100
    BOSS // Custom AI
}

public class Unit : MonoBehaviour
{

    public UnitType unitType;
    public EnemyAI enemyAI;
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int maxEnergy;
    public int currentEnergy;
    public int attackCost;
    public int defense;
    public bool isDefending;

    public bool TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage -= defense;
            isDefending = false;
        }
        currentHP -= damage;
        return currentHP <= 0 ? true : false;
    }

    public void Defend()
    {
        isDefending = true;
    }

    public void StopDefending()
    {
        isDefending = false;
    }

    public void UseEnergy(int energy)
    {
        currentEnergy -= energy;
    }

    public void ResetEnergy()
    {
        currentEnergy = maxEnergy;
    }

    public void Heal(int heal)
    {
        currentHP += heal;
    }

    public bool BelowQuarterHP()
    {
        return currentHP <= maxHP / 4;
    }

}
