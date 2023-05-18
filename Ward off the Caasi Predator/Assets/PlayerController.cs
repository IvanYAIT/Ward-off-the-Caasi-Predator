using UnityEngine;

public class PlayerController
{
    public void Move(Rigidbody2D rb, Vector2 moveDirection, float speed)
    {
        rb.AddForce(new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime));
    }

    public void Fire(Vector2 shootDirection, GameObject bulletPrefab)
    {

    }
}