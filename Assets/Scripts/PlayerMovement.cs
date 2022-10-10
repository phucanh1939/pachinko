using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;

    private Camera _mainCamera;
    private float _minX, _maxX;

    private void Awake()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        _mainCamera = Camera.main;
        if (_mainCamera != null)
        {
            _maxX = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + 0.5f;
            _minX = -_maxX;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _direction = Vector2.left;
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            _direction = Vector2.right;
            _spriteRenderer.flipX = false;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_direction == Vector2.zero) return;
        var position = _rigidbody.position + _speed * Time.deltaTime * _direction;
        if (position.x < _minX)
        {
            position.x = _maxX;
        }
        else if (position.x > _maxX)
        {
            position.x = _minX;
        }
        _rigidbody.MovePosition(position);
    }
}
