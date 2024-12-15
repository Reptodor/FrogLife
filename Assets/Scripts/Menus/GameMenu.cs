using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameMenu : MonoBehaviour
{
    [SerializeField] protected GameObject Panel;

    public void ShowPanel()
    {
        Panel.SetActive(true);
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void BackToMainMenu()
    {
        int mainMenuIndex = 0;
        SceneManager.LoadScene(mainMenuIndex);
    }
}
