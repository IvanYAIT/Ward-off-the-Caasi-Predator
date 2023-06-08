using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int lifeTime;
    [SerializeField] private int radius;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;

    private int _playerLayer;
    private int _enemyLayer;

    private void Awake()
    {
        _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        _enemyLayer = (int)Mathf.Log(enemyLayerMask.value, 2);
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D item in colliders)
        {
            if (item.gameObject.layer == _playerLayer)
                item.GetComponent<Player>().GetDamage();
            if (item.gameObject.layer == _enemyLayer)
                item.GetComponent<IEnemy>().Death();
        }
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}