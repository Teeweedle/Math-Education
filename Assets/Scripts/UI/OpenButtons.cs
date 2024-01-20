using UnityEngine;
using UnityEngine.UI;

public class OpenButtons : MonoBehaviour
{
    [SerializeField] private Animator _openButtonsAnimator;
    [SerializeField] private Animator _craddleButtonAnimator;
    [SerializeField] private Sprite _craddleButtonOpen;
    [SerializeField] private Sprite _craddleButtonClose;
    [SerializeField] private Image _craddleButtonImage;

    private bool _isOpen;
    void Start()
    {
        _isOpen = false;
    }
    public void OnClick()
    {
        if (_isOpen)
        {
            _openButtonsAnimator.SetTrigger("Close Buttons");
            _craddleButtonAnimator.SetTrigger("Craddle Button Close");
            _craddleButtonImage.sprite = _craddleButtonOpen;
            _isOpen = false;
        }
        else
        {
            _openButtonsAnimator.SetTrigger("Open Buttons");
            _craddleButtonAnimator.SetTrigger("Craddle Button Open");
            _craddleButtonImage.sprite = _craddleButtonClose;
            _isOpen = true;
        }            
    }
}
