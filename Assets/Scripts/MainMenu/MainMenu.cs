using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;


    public void Play()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
