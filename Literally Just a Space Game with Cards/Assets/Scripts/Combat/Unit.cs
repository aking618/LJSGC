using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    PLAYER,
    ENEMY
}

public class Unit : MonoBehaviour
{

    public UnitType unitType;
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int maxEnergy;
    public int currentEnergy;
    public int attackCost;
    public int defense;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        return currentHP <= 0 ? true : false;
    }

    public void UseEnergy(int energy)
    {
        currentEnergy -= energy;
    }

    public void ResetEnergy()
    {
        currentEnergy = maxEnergy;
    }

}
