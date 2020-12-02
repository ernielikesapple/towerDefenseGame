using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsLevel : MonoBehaviour
{
    public void level1Chosed() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level1");
    }

    public void level2Chosed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level2");
    }

    public void level3Chosed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level3");
    }
}
