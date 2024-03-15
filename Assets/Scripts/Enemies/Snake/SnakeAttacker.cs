using System;
using UnityEngine;

public class SnakeAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().RecieveDamage(_damage);
        }
    }
}
