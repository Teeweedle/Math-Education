using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class StoreManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _previewImage;
    [SerializeField] private Animator _previewImgAnimator;
    [SerializeField] private GameObject _storeContent;
    [SerializeField] private GameObject _priceTag;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Dictionary<string, string> _storePricesDict = new Dictionary<string, string>();
    [SerializeField] private TextAsset _storePricesFile;

    public delegate bool BuyItem(string aPrice, string aItemName);
    public static event BuyItem _buyItem;

    private const string _STOREITEMS = "Prefabs/Store Items";
    private const string _CANTBUY = "CantBuy";
    private const string _BOUGHT = "CanBuy";
    private string[] _storeText;
    private GameObject[] _storeItems;
    // Start is called before the first frame update
    private void OnEnable()
    {
        PreviewPurchase._checkPrice += ColorPriceText;
    }

    private void ColorPriceText()
    {
        int.TryParse(PlayerProfile._coins, out int lTempProfileCoins);
        int.TryParse(_priceText.text, out int lTempPrice);
        if (lTempProfileCoins < lTempPrice)
        {
            _priceText.color = Color.red;
        }
        else
        {
            _priceText.color = Color.white;
        }
    }

    void Start()
    {      
        _previewImage.enabled = false;
        _priceTag.SetActive(false);        
        LoadStore();
        LoadPrices();
    }
    /// <summary>
    /// Tries to buy the item. Plays animations according to whether you can buy the item or not.
    /// </summary>
    /// <param name="aPrice"></param>
    /// <param name="aItemName"></param>
    public void PurchaseItem(string aPrice, string aItemName)
    {
        if(_buyItem != null)
        {
            if (_buyItem.Invoke(aPrice, aItemName))
            {
                _previewImgAnimator.SetTrigger(_BOUGHT);
            }else
                _previewImgAnimator.SetTrigger(_CANTBUY);
        }
            
    }
    /// <summary>
    /// Loads the image of the item clicked into the larger preview image.
    /// </summary>
    /// <param name="aSprite"></param>
    public void PreviewImage(Sprite aSprite)
    {
        string lPrice = _storePricesDict[aSprite.name];
        _priceTag.SetActive(true); 
        _previewImage.enabled = true;
        _priceText.text = lPrice;
        _previewImage.sprite = aSprite;
    }
    //Calls delegate function to buy item from Active Profile
    public void PurchaseItem()
    {
        PurchaseItem(_priceText.text, _previewImage.sprite.name);        
    }
    /// <summary>
    /// Loads the items available to buy into the scrollview.
    /// </summary>
    private void LoadStore()
    {
        _storeItems = Resources.LoadAll<GameObject>(_STOREITEMS);
        for (int i = 0; i < _storeItems.Length; i++)
        {
            Instantiate(_storeItems[i], _storeContent.transform);
        }
    }
   /// <summary>
   /// Reads text file StorePrices.txt and parse it into a dictionary for the store to reference.
   /// </summary>
    private void LoadPrices()
    {
        string[] lString;
        _storeText = _storePricesFile.text.Split(Environment.NewLine);
        foreach (string line in _storeText)
        {
            lString = line.Split('=');
            _storePricesDict.Add(lString[0], lString[1]);
        }
    }
    private void OnDisable()
    {
        PreviewPurchase._checkPrice -= ColorPriceText;
    }
    private void OnDestroy()
    {
        _buyItem = null;
    }
}
