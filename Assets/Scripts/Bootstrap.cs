using Cinemachine;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Spawners")]
    [SerializeField] private Spawner[] _spawners;

    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private float _maxExperienceValue;
    private IInput _playerInput;

    private void Awake()
    {
        InitializeDevice();
        InitializePlayer();
        InitializeSpawners();
    }

    private void InitializeDevice()
    {
        bool isMobile = false;

        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            isMobile = false;
            _playerInput = new DesktopInputHandler();
        }
        else
        {
            isMobile = true;
            _playerInput = new MobileInputHandler(_joystick);
        }

        _joystick.gameObject.SetActive(isMobile);
    }

    private void InitializeSpawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Initialize();
        }
    }

    private void InitializePlayer()
    {
        Player player = Instantiate(_player);
        player.Initialize(_playerInput, _maxExperienceValue);
        _playerCamera.Follow = player.transform;
    }
}
