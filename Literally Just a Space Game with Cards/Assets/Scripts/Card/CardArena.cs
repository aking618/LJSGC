using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArena : MonoBehaviour
{
    public GameObject cardGO;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cardGO, gameObject.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
