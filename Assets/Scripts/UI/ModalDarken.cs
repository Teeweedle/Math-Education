using System;
using UnityEngine;
using System.Threading.Tasks;

public class ModalDarken : MonoBehaviour
{
    private const string _SHOWDARKEN = "Show";
    private const string _HIDEDARKEN = "Hide";

    [SerializeField] private Animator _darkenBehindModalAnimator;
    [SerializeField] private GameObject _darkenBehindModal;

    private bool _isShowing;
    private void OnEnable()
    {
        GameFinishPopup._darken += ToggleDarken;
        ProfileButton._darken += ToggleDarken;
    }

    private async void ToggleDarken()
    {
        if (_isShowing)
        {
            _darkenBehindModalAnimator.SetTrigger(_HIDEDARKEN);
            await Task.Delay(1000);
            _darkenBehindModal.SetActive(false);
        }
        else
        {
            _darkenBehindModal.SetActive(true);
            _darkenBehindModalAnimator.SetTrigger(_SHOWDARKEN);
        }
        _isShowing = !_isShowing;
    }

    void Start()
    {
        _isShowing = false;
        _darkenBehindModal.SetActive(false);
    }
    private void OnDisable()
    {
        GameFinishPopup._darken -= ToggleDarken;
        ProfileButton._darken -= ToggleDarken;
    }

}
