using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class View1Script : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

}
