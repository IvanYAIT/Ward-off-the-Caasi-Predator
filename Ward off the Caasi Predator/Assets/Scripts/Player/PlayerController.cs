using UnityEngine;

public class PlayerController
{
    private BulletPool _pool;

    public PlayerController(BulletPool pool)
    {
        _pool = pool;
    }

    public void Move(Rigidbody2D rb, Vector2 moveDirection, float speed)
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void Fire(Transform parent, float bulletSpeed)
    {
        for (int i = 0; i < _pool.Bullets.Count; i++)
        {
            if (!_pool.Bullets[i].activeSelf)
            {
                GameObject obj = _pool.Bullets[i];
                obj.SetActive(true);
                obj.transform.position = parent.GetChild(0).position;
                obj.transform.rotation = parent.rotation;
                obj.GetComponent<Bullet>().SetSpeed(bulletSpeed);
                return;
            }
        }
    }
}