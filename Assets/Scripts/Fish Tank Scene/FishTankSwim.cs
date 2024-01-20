using UnityEngine;

public class FishTankSwim : MonoBehaviour
{
    //[SerializeField] private Animator _animator;
    //[SerializeField] private Rect _rect;
    private const string _FISHTANK = "Fish Tank";
    private Vector2 _size;
    private float _speed;
    private Vector3 _movePoint;

    private void OnEnable()
    {
        DragItem._onItemDrag += StartUp;
    }
    void Start()
    {        
        //_rect = GetComponent<Rect>();        
        //_animator = GetComponent<Animator>();
        _speed = Random.Range(0.2f, 0.8f);
        //_animator.speed = _speed / 2;

        if (this.gameObject.tag.Equals(_FISHTANK))
        {
            _movePoint = SetDirection();
        }
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoint, _speed);
        //transform.position = Vector3.Lerp(transform.position, _movePoint, _speed / 300);
        if (IsInRange(_movePoint))
        {
            _movePoint = SetDirection();
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
        DragItem._onItemDrag -= StartUp;
    }
}
