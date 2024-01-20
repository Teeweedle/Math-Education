using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private const string _VOLUME = "Volume";

    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Image _soundButtonImage;
    [SerializeField] private Slider _volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(_VOLUME))
        {
            PlayerPrefs.SetFloat(_VOLUME, 1.0f);
        }
        SetInitialVolume();
    }
    /// <summary>
    /// Adjust volume based on slider position. Swaps image for muted image if sound = 0.
    /// </summary>
    public void AdjustAudio()
    {
        _audioSource.volume = _volumeSlider.value;
        if (_audioSource.volume == 0)
            _soundButtonImage.sprite = _soundOff;        
        else
            _soundButtonImage.sprite = _soundOn;
        PlayerPrefs.SetFloat(_VOLUME, _volumeSlider.value);
    }
    /// <summary>
    /// Sets initial volume and volume slider position based on PlayerPrefs.
    /// </summary>
    public void SetInitialVolume()
    {
        _audioSource.volume = PlayerPrefs.GetFloat(_VOLUME);
        _volumeSlider.value = PlayerPrefs.GetFloat(_VOLUME);
    }
}
