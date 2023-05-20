using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _shootSpeed;
    [Header("Other")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _head;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private InputListener inputListener;

    void Start()
    {
        inputListener.Construct(_playerSpeed, _rb, _head, _bulletPrefab, _shootSpeed);
    }
}
