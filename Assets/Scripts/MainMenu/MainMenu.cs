using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _nextSceneNumber;
    
    public void Play()
    {
        SceneManager.LoadScene(_nextSceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
