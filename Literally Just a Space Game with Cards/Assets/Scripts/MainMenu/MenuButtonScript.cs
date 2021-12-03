using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("WorldTraversal");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
