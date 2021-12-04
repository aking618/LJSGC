using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    public bool isEnabled = false;
    public bool isHover = false;

    public Vector3 originalPosition;

    public void Start()
    {
        originalPosition = transform.position;
    }

    public void Update()
    {
        if(transform.position.y > originalPosition.y + 0.2)
        {
            return;
        }
        if(isHover)
        {
             transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
    }

    private void OnMouseDown()
    {
        // load scene
        if (isEnabled)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
    
    private void OnMouseEnter()
    {
        isHover = true;
    }

    private void OnMouseExit()
    {
        transform.position = originalPosition;
        isHover = false;
    }
}
