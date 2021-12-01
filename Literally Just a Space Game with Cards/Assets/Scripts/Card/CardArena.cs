using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArena : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> cardSlots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int slotIndex = 0;
        foreach(GameObject card in hand)
        {
            Debug.Log(cardSlots[slotIndex].transform);
            Vector3 vec = cardSlots[slotIndex].transform.position;
            Instantiate(card, vec, Quaternion.identity);
 
            slotIndex++;
        }

        //Instantiate(cardGO, gameObject.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
