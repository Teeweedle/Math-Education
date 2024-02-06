using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrefabSelection : MonoBehaviour
{
    private const string _MERMAIDS = "Mermaids";

    [SerializeField] private TextMeshProUGUI _buttonText;

    public delegate void PrefabSelected(string aName);
    public static event PrefabSelected _onPrefabSelected;

    private void Start()
    {        
        if (_buttonText.text.Equals(_MERMAIDS))
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            PlayerInfo._prefabSelection = _MERMAIDS;
        }
    }
    /// <summary>
    /// Passes the text on the button click to an event.
    /// </summary>
    public void OnClick()
    {        
        PlayerInfo._prefabSelection = _buttonText.text;
        _onPrefabSelected?.Invoke(_buttonText.text);
    }
}
