using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
}
