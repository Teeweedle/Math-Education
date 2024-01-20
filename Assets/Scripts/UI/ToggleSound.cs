using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{    
    [SerializeField] private GameObject _volumeSlider;
  
    public void OnClick()
    {
        if (_volumeSlider.activeSelf)
        {
            _volumeSlider.SetActive(false);
        }
        else
        {
            _volumeSlider.SetActive(true);
        }
    } 
}
