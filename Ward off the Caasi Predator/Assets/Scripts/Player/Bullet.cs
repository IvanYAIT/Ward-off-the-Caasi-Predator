using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float _speed;

    private void Move()
    {
        rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
