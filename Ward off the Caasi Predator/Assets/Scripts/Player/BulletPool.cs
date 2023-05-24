using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    public List<GameObject> Bullets { get; private set; }

    private GameObject _bulletPrefab;

    public BulletPool(int bulletAmount, GameObject bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
        Bullets = new List<GameObject>();
        InitPool(bulletAmount);
    }

    private void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            Bullets.Add(Object.Instantiate(_bulletPrefab));
        }
    }

    public GameObject Get(int index) => Bullets[index];

    public void Return(GameObject item) => Bullets.Add(item);
}