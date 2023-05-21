using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private float _speed;
    private float _bulletSpeed;
    private Rigidbody2D _rb;
    private Transform _head;
    private GameObject _bulletPrefab;
    private float _shootSpeed;

    private PlayerController _playerController;
    private PlayerInput _playerInput;
    private InputAction _move;
    private InputAction _fire;
    private bool onCooldown;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerController = new PlayerController();
    }

    private void OnEnable()
    {
        _move = _playerInput.Player.Move;
        _fire = _playerInput.Player.Fire;
        _move.Enable();
        _fire.Enable();
    }

    private void OnDisable()
    {
        _move.Disable();
        _fire.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _move.ReadValue<Vector2>();
        _playerController.Move(_rb, moveDirection, _speed);

        if (!onCooldown && _fire.IsPressed())
        {
            StartCoroutine(Shoot());
        }
            
    }

    private IEnumerator Shoot()
    {
        onCooldown = true;
        Vector2 fireDirection = _fire.ReadValue<Vector2>();
        if (fireDirection.x == 1 || fireDirection.x == -1)
            _head.rotation = Quaternion.AngleAxis(-90 * fireDirection.x, Vector3.forward);
        else if (fireDirection.y == 1)
            _head.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        else if (fireDirection.y == -1)
            _head.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        _playerController.Fire(_head, _bulletPrefab, _bulletSpeed);
        yield return new WaitForSeconds(_shootSpeed);
        onCooldown = false;
    }

    public void Construct(float speed, Rigidbody2D rb, Transform head, GameObject bulletPrefab, float shootSpeed, float bulletSpeed)
    {
        _bulletSpeed = bulletSpeed;
        _rb = rb;
        _speed = speed;
        _shootSpeed = shootSpeed;
        _head = head;
        _bulletPrefab = bulletPrefab;
    }
}
