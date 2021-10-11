using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int maxEnergy;
    public int currentEnergy;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        return currentHP <= 0 ? true : false;
    }

}
