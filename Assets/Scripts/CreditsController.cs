using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{

    private void Update()
    {
        OpenMainMenu();
    }
    
    private void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
