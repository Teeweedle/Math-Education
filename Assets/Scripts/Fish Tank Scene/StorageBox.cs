using UnityEngine;
using UnityEngine.EventSystems;

public class StorageBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _boxAnimator;

    private const string _SHOWBOX = "Show";
    private const string _HIDEBOX = "Hide";
    private const string _ENLARGEBOX = "Mouse Over";
    private const string _SHRINKBOX = "Mouse Exit";

    public delegate void OverStorage(bool aIsOver);
    public static event OverStorage _overStorage;

    private void OnEnable()
    {
        DragItem._onItemDrag += ToggleStorageBox;
    }
    private void ToggleStorageBox(bool aIsDragging)
    {
        if(aIsDragging)
        {
            _boxAnimator.SetTrigger(_SHOWBOX);
        }
        else
        {
            _boxAnimator.SetTrigger(_HIDEBOX);
        }        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _overStorage?.Invoke(true);
        _boxAnimator.SetTrigger(_ENLARGEBOX);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _overStorage?.Invoke(false);
        _boxAnimator.SetTrigger(_SHRINKBOX);
    }
    private void OnDisable()
    {
        DragItem._onItemDrag -= ToggleStorageBox;
    }
    private void OnDestroy()
    {
        _overStorage = null;
    }
}
