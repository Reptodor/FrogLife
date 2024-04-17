using UnityEngine;

public class FishSound : MonoBehaviour
{
    [SerializeField] private AudioSource _fishSound;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _seeDistanceHorizontal;
    [SerializeField] private float _seeDistanceVertical;
    [SerializeField] private bool _seePlayer;
    private FishSound _fishSoundInstace;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _fishSoundInstace = this;
    }

    private void Update()
    {
        LookingForPlayer();
    }

    private void LookingForPlayer()
    {
        if (((transform.position.x - _player.transform.position.x >= -_seeDistanceHorizontal) &&
             (transform.position.x - _player.transform.position.x <= _seeDistanceHorizontal)) &&
            ((transform.position.y - _player.transform.position.y >= -_seeDistanceVertical) &&
             (transform.position.y - _player.transform.position.y <= _seeDistanceVertical)))
        {
            _fishSound.Play();
            _fishSoundInstace.enabled = false;
        }
    }
}
