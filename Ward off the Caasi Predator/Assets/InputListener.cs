using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private PlayerController _playerController;
    private PlayerInput _playerInput;
    private InputAction _move;
    private InputAction _fire;

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
        _playerController.Move(rb, moveDirection, speed);
    }
}
