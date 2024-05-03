using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneLoader.SceneLoaderInstance.LoadNextScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
