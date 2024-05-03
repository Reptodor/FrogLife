using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int _currentSceneNumber;

    public static SceneLoader SceneLoaderInstance;

    private void Awake()
    {
        SceneLoaderInstance = this;
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(_currentSceneNumber);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneNumber + 1);
    }
}
