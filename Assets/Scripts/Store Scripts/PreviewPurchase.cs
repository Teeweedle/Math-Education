using UnityEngine;
using UnityEngine.EventSystems;

public class PreviewPurchase : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private BoxCollider2D _boxCollider;

    public delegate void CheckPrice();
    public static event CheckPrice _checkPrice;

    private const string _PREVIEWIMAGE = "Preview Image";
    private const int _COLLIDERSIZE = 200;
    private void OnEnable()
    {
        //set clickable area to the size of the image
        _boxCollider.size = new Vector2(_COLLIDERSIZE, _COLLIDERSIZE);
    }

    public void OnPointerDown(PointerEventData eventData)
    {        
        //send this image to preview window
        StoreManager lStoreManager = GameObject.Find(_PREVIEWIMAGE)
            .GetComponent<StoreManager>();
        lStoreManager.PreviewImage(_image.sprite);
        _checkPrice?.Invoke();
    }
}
