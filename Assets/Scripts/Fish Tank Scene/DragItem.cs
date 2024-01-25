using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{    
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private GameObject _myFishTank;

    private const int _COLLIDERSIZE = 200;
    private Vector2 _itemPostion = Vector2.zero;
    private bool _isOverStorage = false;
    private const string _FISHTANK = "Fish Tank";
    private const string _UNTAGGED = "Untagged";

    public delegate void ItemDrag(bool isDragging);
    public static event ItemDrag _onItemDrag;

    public delegate void StoreItem(GameObject aGameObject, string aName);
    public static event StoreItem _storeItem;

    public delegate void RemoveFromStorage(string aItemName);
    public static event RemoveFromStorage _removeFromStorage;

    void OnEnable()
    {
        StorageBox._overStorage += OverStorage;
    }
    private void Start()
    {
        //set clickable area to the size of the image
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.size = new Vector2(_COLLIDERSIZE, _COLLIDERSIZE);
        _myFishTank = GameObject.Find("Fish Tank");        
        _image = GetComponent<UnityEngine.UI.Image>();
    } 
    //remove item from scroll view
    //place item in the canvas root
    public void OnBeginDrag(PointerEventData eventData)
    {
        _onItemDrag?.Invoke(true);
        _itemPostion = transform.position;
        //if objects moves; disable the move
        if (!this.gameObject.GetComponent<RewardItemProperties>()._IsStatic)
        {
            SendMessage("StartUp", true);
            this.gameObject.GetComponent<FishTankSwim>().enabled = false;
        }        
        if (!this.gameObject.CompareTag(_FISHTANK))
        {
            this.transform.SetParent(_myFishTank.transform);
            this.tag = _FISHTANK;
            _removeFromStorage?.Invoke(_image.sprite.name);
        }
    }
    //update item position based on mouse location
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _itemPostion = eventData.position;
    }
    //set item position based on last mouse position at end of drag
    //save in world location dictionary
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isOverStorage)
        {
            AddToStorage();
        }
        else
        {
            //if objects moves; disable the move
            if (!this.gameObject.GetComponent<RewardItemProperties>()._IsStatic)
            {
                this.gameObject.GetComponent<FishTankSwim>().enabled = true;
                SendMessage("StartUp", false);
            }
        }
        transform.position = _itemPostion;
        _onItemDrag?.Invoke(false);

    }
    /// <summary>
    /// Adds item to collection list and untags it so it isn't saved to fish tank.
    /// </summary>
    private void AddToStorage()
    {
        _storeItem?.Invoke(this.gameObject, _image.sprite.name);
        this.gameObject.tag = _UNTAGGED;
    }
    /// <summary>
    /// Updates based on if mouse is over storage box.
    /// </summary>
    /// <param name="aIsOverStorage"></param>
    private void OverStorage(bool aIsOverStorage)
    {
        _isOverStorage = aIsOverStorage;
    }
    private void OnDestroy()
    {
        _onItemDrag = null;
        _removeFromStorage = null;
        _storeItem = null;
    }
}
