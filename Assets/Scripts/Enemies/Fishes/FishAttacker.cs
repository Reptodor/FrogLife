using UnityEngine;

public class FishAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().RecieveDamage(_damage);
        }
    }
}
