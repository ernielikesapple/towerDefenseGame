using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelUp : MonoBehaviour
{

    public string nextLevel = "level2";

    public void Continue()
    {
        SceneManager.LoadScene(nextLevel);

    }

    public void Exit()
    {
        Application.Quit();
    }

}
