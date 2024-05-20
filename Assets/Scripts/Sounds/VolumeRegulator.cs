using UnityEngine;
using UnityEngine.UI;

public class VolumeRegulator : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    private readonly string _volumeKey = "Volume";

    private void Awake()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat(_volumeKey, 1);
    }

    private void Update()
    {
        ChooseVolume();
    }

    private void ChooseVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        PlayerPrefs.SetFloat(_volumeKey, _volumeSlider.value);
    }
}
