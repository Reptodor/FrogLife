using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoader.SceneLoaderInstance.LoadNextScene();
        }
    }
}
