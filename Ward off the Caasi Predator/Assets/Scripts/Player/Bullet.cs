using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask enemyLayerMask;

    private float _speed;
    private float _damage;
    private int _enemyLayer;

    private void Awake()
    {
        _enemyLayer = (int)Mathf.Log(enemyLayerMask.value, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _enemyLayer)
            collision.gameObject.GetComponent<IEnemy>().GetDamage(_damage);
        gameObject.SetActive(false);
    }

    private void Move()
    {
        rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
        Move();
    }

    public void SetDamage(float damage) => _damage = damage;
}
