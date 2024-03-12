using UnityEngine;

public class SeaweedCollector : MonoBehaviour
{
    [SerializeField] private int _experienceInside = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ExperienceChanger>())
        {
            other.gameObject.GetComponent<ExperienceChanger>().GainingExperience(_experienceInside);
            SeaweedSpawner.Spawned--;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(("Wall")))
        {
            SeaweedSpawner.Spawned--;
            Destroy(gameObject);
        }
    }
}
