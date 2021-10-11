using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI energyText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel.ToString();
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        if (unit.unitType == UnitType.PLAYER)
        {
            energyText.text = "Energy: " + unit.currentEnergy.ToString() + "/" + unit.maxEnergy.ToString();
        }
        else
        {
            energyText.text = "";
        }
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void UpdateEnergy(Unit unit)
    {
        if (unit.unitType == UnitType.PLAYER)
        {
            energyText.text = "Energy: " + unit.currentEnergy.ToString() + "/" + unit.maxEnergy.ToString();
        }
    }
}
