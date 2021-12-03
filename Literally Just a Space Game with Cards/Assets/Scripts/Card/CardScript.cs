using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CardScript : MonoBehaviour
{

    public string cardName;
    public string cardDescription;
    public int cardCost;
    public CardType cardType;
    public CardTarget cardTarget;

    public virtual void OnCardPlayed()
    {
        Debug.Log("Card Played");
    }

    public void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }

    public IEnumerator UpdateUI(string text)
    {
        Debug.Log("Updating UI");
        GameObject.Find("Dialoge Text").GetComponent<TextMeshProUGUI>().text = text;
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("Dialoge Text").GetComponent<TextMeshProUGUI>().text = "Choose an action:";
    }

    public IEnumerator HandleWin()
    {
        Debug.Log("Handling Win");
        GameObject.Find("Dialoge Text").GetComponent<TextMeshProUGUI>().text = "You Win!";
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("Dialoge Text").GetComponent<TextMeshProUGUI>().text = "Returning to Space!";
        yield return new WaitForSeconds(1.0f);

        // return to other scene
        SceneManager.LoadScene("WorldTraversal");

    }

    public bool IsPlayerTurn(BattleState battleState)
    {
        if (battleState == BattleState.PLAYERTURN)
        {
            return true;
        }

        return false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
