using UnityEngine;

public class PlayerController
{
    public void Move(Rigidbody2D rb, Vector2 moveDirection, float speed)
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void Fire(Transform parent, GameObject bulletPrefab, float bulletSpeed)
    {
        GameObject obj = Object.Instantiate(bulletPrefab, parent.GetChild(0).position, parent.rotation);
        obj.GetComponent<Bullet>().SetSpeed(bulletSpeed);
    }
}