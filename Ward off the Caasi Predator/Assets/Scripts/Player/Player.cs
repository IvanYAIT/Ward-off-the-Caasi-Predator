using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask doorLayerMask;

    private int _doorLayer;

    private void Start()
    {
        _doorLayer = (int)Mathf.Log(doorLayerMask.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _doorLayer)
        {
            switch (collision.gameObject.tag.ToLower())
            {
                case "left":
                    transform.position = new Vector2(transform.position.x - 3, transform.position.y);
                    break;
                case "right":
                    transform.position = new Vector2(transform.position.x + 3, transform.position.y);
                    break;
                case "up":
                    transform.position = new Vector2(transform.position.x, transform.position.y + 4);
                    break;
                case "down":
                    transform.position = new Vector2(transform.position.x, transform.position.y - 4);
                    break;
            }
        }
    }
}
