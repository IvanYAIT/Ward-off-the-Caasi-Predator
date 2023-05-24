using UnityEngine;

[CreateAssetMenu(fileName = "Player�haracteristics", menuName = "SO/NewPlayer�haracteristics")]
public class Player�haracteristics : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private float damage;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float bulletSpeed;

    public int Health => health;
    public float Damage => damage;
    public float PlayerSpeed => playerSpeed;
    public float ShootSpeed => shootSpeed;
    public float BulletSpeed => bulletSpeed;
}
