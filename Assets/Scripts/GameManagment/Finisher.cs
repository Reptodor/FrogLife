using UnityEngine;

public class Finisher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<FrogMovement>() != null)
        {
            SceneLoader.SceneLoaderInstance.LoadNextScene();
        }
    }
}
