using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour
{

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
