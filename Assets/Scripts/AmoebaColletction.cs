using UnityEngine;

public class AmoebaColletction : MonoBehaviour
{
    [SerializeField] private int _expInside= 1;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<ExpirienceController>().GainingExpirience(_expInside);
            Respawner.Spawned--;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(("Wall")))
        {
            Respawner.Spawned--;
            Destroy(gameObject);
        }
    }
}
