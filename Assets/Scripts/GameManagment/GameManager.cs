using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _escMenu;
    [SerializeField] private int _sceneNumber;
    [SerializeField] private bool _isEscMenuOpened = false;

    private void Update()
    {
        ControlEscMenu();

        if (_isEscMenuOpened)
        {
            _escMenu.SetActive(true);
        }
        else
        {
            _escMenu.SetActive(false);
        }
    }


    public void CloseEscMenu()
    {
        _isEscMenuOpened = false;
        Time.timeScale = 1;
    }
    
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(++_sceneNumber);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneNumber);
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
