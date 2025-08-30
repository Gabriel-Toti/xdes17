using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    float _moveInput = 0;
    [SerializeField] Transform _gun;
    [SerializeField] GameObject _laser;
    [SerializeField] float _speed;
    [SerializeField] float _fireRate = 10; //x por segundo
    [SerializeField] bool _flip;
    float _fireTime = 0;
    bool _isShooting = false;
    Vector3 _direction;
    Vector2 _moveAxis;

    void Shoot()
    {
        if (!_isShooting) return;

        float delta = Time.time - _fireTime;

        if (delta < 1 / _fireRate) return;

        Instantiate(_laser, _gun.position, Quaternion.Euler(_direction));

        _fireTime = Time.time;
    }

    public void MoveCallback(InputAction.CallbackContext _callbackContext)
    {
        _moveInput = _flip ? _callbackContext.ReadValue<Vector2>().x : _callbackContext.ReadValue<Vector2>().y;
    }

    public void AttackCallback(InputAction.CallbackContext _callbackContext)
    {
        _isShooting = _callbackContext.performed;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = _flip ? new Vector3(0, 0, 90) : transform.eulerAngles;
        _moveAxis = new(math.sin(math.TORADIANS * _direction.z) * _speed, math.cos(math.TORADIANS * _direction.z) * _speed );
    }

    void FixedUpdate()
    {
        _rb.linearVelocityY = _moveInput * Time.fixedDeltaTime * _moveAxis.y;
        _rb.linearVelocityX = _moveInput * Time.fixedDeltaTime * _moveAxis.x;
    }

    void LateUpdate()
    {
        Shoot();
    }

}
