using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCollection : MonoBehaviour
{    
    [SerializeField] private GameObject _myCollectionContent;
    [SerializeField] private GameObject _myFishTank;
    [SerializeField] private Image _scrollViewImage;
    [SerializeField] private Image _contentImage;
    [SerializeField] private Animator _collectionAnimator;

    private const string _RESOURCEPATH = "Prefabs/Store Items/";
    private const string _FISHTANK = "Fish Tank";
    private const string _SHOWCOLLECTION = "Show";
    private const string _HIDECOLLECTION = "Hide";
    private int _collectionCount;
    private void OnEnable()
    {
        DragItem._storeItem += PutBackInCollection;
        DragItem._onItemDrag += ToggleCollection;
        DragItem._removeFromStorage += RemoveFromStorage;
    }
    /// <summary>
    /// Hides collection list when dragging an item. Saves fish tank when dragging is done.
    /// </summary>
    /// <param name="aIsDragging"></param>
    private void ToggleCollection(bool aIsDragging)
    {
        if (aIsDragging)
        {
            _collectionAnimator.SetTrigger(_HIDECOLLECTION);
        }
        else
        {
            _collectionAnimator.SetTrigger(_SHOWCOLLECTION);
            SaveFishTank();
        }        
    }

    private void OnDisable()
    {
        DragItem._storeItem -= PutBackInCollection;
    }
    void Start()
    {
        _collectionCount = 0;
        ShowCollection(PlayerProfile._collectionScrollList);
        DisplayFishTank();
    }
    /// <summary>
    /// Display collection in the scrollview. Disables FishTankSwim so the objects down't move while in the list.
    /// </summary>
    /// <param name="aCollection"></param>
    private void ShowCollection(List<string> aCollection)
    {
        GameObject lTempObj = null;
        foreach (string a in aCollection)
        {
            _collectionCount++;
            lTempObj = Instantiate(Resources.Load<GameObject>(_RESOURCEPATH + a), _myCollectionContent.transform);
            Destroy(lTempObj.GetComponent<PreviewPurchase>());
            lTempObj.AddComponent<DragItem>();
            DisableSwim(lTempObj);
        }
        CheckCollectionSize(_collectionCount);
    }  
    public void PutBackInCollection(GameObject aItemObj, string aItemName)
    {
        aItemObj.transform.SetParent(_myCollectionContent.transform);
        AddToCollectionList(aItemName);
    }
    public void DisplayFishTank()
    {
        if (PlayerProfile._itemNameList.Count > 0)
            LoadFishTank(PlayerProfile._itemNameList, PlayerProfile._itemPositionList);
    }
    /// <summary>
    /// Hide Collection List if the list is empty.
    /// </summary>
    /// <param name="aInt"></param>
    private async void CheckCollectionSize(int aInt)
    {
        if (aInt == 0){
            await Task.Delay(400);
            _scrollViewImage.enabled = false;
            _contentImage.enabled = false;
        }
        else{
            _scrollViewImage.enabled = true;
            _contentImage.enabled = true;
        }
    }
    public void RemoveFromStorage(string aItemName)
    {        
        if (PlayerProfile._collectionScrollList.Contains(aItemName))
        {
            _collectionCount--;
            CheckCollectionSize(_collectionCount);
            PlayerProfile._collectionScrollList.Remove(aItemName);
        }
    }
    private void AddToCollectionList(string aItemName)
    {
        _collectionCount++;
        CheckCollectionSize(_collectionCount);
        PlayerProfile._collectionScrollList.Add(aItemName);
    }
    /// <summary>
    /// Searches for items "in" the "Fish Tank" (searches for the tag) and saves the name to a list.
    /// Saves the Vector2 for that item to a list.
    /// The element spots correspond to each other. item[0].name = item[0].pos.
    /// Then saves the active profile.
    /// </summary>   
    public void SaveFishTank()
    {
        List<GameObject> lGameObjList = new List<GameObject>();
        List<string> lNameList = new List<string>();
        List<Vector2> lPositionList = new List<Vector2>();

        lGameObjList = GameObject.FindGameObjectsWithTag(_FISHTANK).ToList();
        int lIndex = 0;
        //filters name of object by first "(" and removes everything else
        foreach (GameObject gameObj in lGameObjList)
        {
            lIndex = gameObj.name.IndexOf("(");
            lNameList.Add(gameObj.name.Substring(0, lIndex));
            lPositionList.Add(gameObj.transform.position);
        }
        PlayerProfile._itemNameList = lNameList;
        PlayerProfile._itemPositionList = lPositionList;
        PlayerProfile.SaveProfile();
    }
    /// <summary>
    /// Instantiates gameObjects based on their position in their repsective lists to fill fish tank
    /// to their saved positions. Removes PreviewPurchase script.
    /// </summary>
    /// <param name="aNameList"></param>
    /// <param name="aPositionList"></param>
    private void LoadFishTank(List<string> aNameList, List<Vector2> aPositionList)
    {
        GameObject lTempObj = null;
        int lIndex = 0;
        foreach (string name in aNameList)
        {
            lTempObj = Instantiate(Resources.Load<GameObject>(_RESOURCEPATH + name), aPositionList[lIndex],
                Quaternion.identity, _myFishTank.transform);
            lTempObj.tag = _FISHTANK;
            Destroy(lTempObj.GetComponent<PreviewPurchase>());
            EnableSwim(lTempObj);
            lTempObj.AddComponent<DragItem>();
            lIndex++;
        }
    }
    /// <summary>
    /// Checks if object is not static, then disables if it is
    /// </summary>
    /// <param name="aGameObject"></param>
    private void DisableSwim(GameObject aGameObject)
    {
        if (!aGameObject.GetComponent<RewardItemProperties>()._IsStatic)
            aGameObject.GetComponent<FishTankSwim>().enabled = false;
    }
    /// <summary>
    /// Checks if object is not static, then enables if it is
    /// </summary>
    /// <param name="aGameObject"></param>
    private void EnableSwim(GameObject aGameObject)
    {
        if (!aGameObject.GetComponent<RewardItemProperties>()._IsStatic)
            aGameObject.GetComponent<FishTankSwim>().enabled = true;
    }
}
