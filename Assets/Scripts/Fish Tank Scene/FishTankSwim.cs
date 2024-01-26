using UnityEngine;
using UnityEngine.UIElements;

public class FishTankSwim : MonoBehaviour
{
    private const string _FISHTANK = "Fish Tank";
    private float _speed;
    private Vector3 _movePoint, _left, _right;

    private void OnEnable()
    {
        //DragItem._onItemDrag += StartUp;
    }
    void Start()
    {
        _left = new Vector3(-1, 1, 1);
        _right = new Vector3(1, 1, 1);
        _speed = Random.Range(0.1f, 0.3f);

        if (this.gameObject.CompareTag(_FISHTANK))
        {
            _movePoint = SetDirection();
        }
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoint, _speed);
        FaceDirection();
        if (IsInRange(_movePoint))
        {
            _movePoint = SetDirection();
        }
    }

    private void FaceDirection()
    {
        if ((_movePoint - transform.position).x >= 0)
        {
            this.gameObject.GetComponent<RectTransform>().localScale = _left;
        }
        else
        {
            this.gameObject.GetComponent<RectTransform>().localScale = _right;
        }
    }

    /// <summary>
    /// Triggered when dragging item ends.
    /// </summary>
    /// <param name="isDragging"></param>
    private void StartUp(bool isDragging)
    {
        _movePoint = SetDirection();
    }
    private Vector3 SetDirection()
    {
        float xPos  = Random.Range(0, Screen.width);
        float yPos = Random.Range(0, Screen.height);
        return new Vector3(xPos, yPos, 0);
    }       
    public bool IsInRange(Vector3 aTarget)
    {
        return Vector2.Distance(this.transform.position, aTarget) < 0.05f;
    }
    private void OnDisable()
    {
        //DragItem._onItemDrag -= StartUp;
    }
}
