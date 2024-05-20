using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _escMenu;
    [SerializeField] private bool _isEscMenuOpened = false;

    private void Update()
    {
        ControlEscMenu();
        
        _escMenu.SetActive(_isEscMenuOpened);
    }
    
    public void CloseEscMenu()
    {
        _isEscMenuOpened = false;
        Time.timeScale = 1;
    }
    
    public void Play()
    {
        Time.timeScale = 1;
        SceneLoader.SceneLoaderInstance.LoadNextScene();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneLoader.SceneLoaderInstance.RestartCurrentScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    private void ControlEscMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isEscMenuOpened)
        {
            Time.timeScale = 0;
            _isEscMenuOpened = true;
        }
        else if (_isEscMenuOpened && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            _isEscMenuOpened = false;
        }
    }
}
