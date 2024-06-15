using System;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bushCanvas;
    private bool _inBush;
    

    private void Awake()
    {
        _inBush = false;
    }

    private void Update()
    {
        HidePlayer();
    }

    private void HidePlayer()
    {
        if (_inBush)
        {
            _bushCanvas.SetActive(true);
        }
        
        if (_inBush && Input.GetKeyDown(KeyCode.E))
        {
            _player.SetActive(false);
        }
        else if(!_inBush && Input.GetKeyDown(KeyCode.E))
        {
            _player.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            _inBush = true;
            _bushCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            _inBush = false;
            _bushCanvas.SetActive(false);
        }
    }

}
