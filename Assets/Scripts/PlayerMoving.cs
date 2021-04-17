using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMoving : MonoBehaviour
{
    [Header("Jump power")]
    [SerializeField] private float _jumpImpulse;
    [Header("Moving speed")]
    [SerializeField] private float _speed;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _velocity;
    private bool _grounded;    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _velocity = new Vector2(Input.GetAxis("Horizontal"), 0) * _speed;

        FlipSprite();
        EnableJump();
    }

    private void FixedUpdate()
    {
        if (_grounded)
        {
            _rigidbody.velocity = _velocity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Grid>(out Grid grid) || collision.TryGetComponent<EnemyMoving>(out EnemyMoving enemy))
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }

    private void EnableJump()
    {
        if (Input.GetKey(KeyCode.Space) && _grounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpImpulse, ForceMode2D.Impulse);
            _grounded = false;
            _animator.SetTrigger("Jump");
        }
    }

    private void FlipSprite()
    {
        if (_velocity.x > 0)
        {
            _sprite.flipX = false;
            _animator.SetTrigger("Run");
        }
        else if (_velocity.x < 0)
        {
            _sprite.flipX = true;
            _animator.SetTrigger("Run");
        }
    }
}