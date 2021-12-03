using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{

    public bool isEnabled = false;

    private void OnMouseDown()
    {
        // load scene
        if (isEnabled)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
