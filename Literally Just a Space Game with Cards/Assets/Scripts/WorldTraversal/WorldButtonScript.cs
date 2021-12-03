using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldButtonScript : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
