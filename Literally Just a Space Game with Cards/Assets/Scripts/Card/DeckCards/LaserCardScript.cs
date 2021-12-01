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
        enemyUnit.TakeDamage(6);
        Debug.Log("LaserCardScript.OnPlay()");
    }

}
