using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private StoreManager _storeManager;

    public void OnClick()
    {
        _storeManager.PurchaseItem();
    }
}
