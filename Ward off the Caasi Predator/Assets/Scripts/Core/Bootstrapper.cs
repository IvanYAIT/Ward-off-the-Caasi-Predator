using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private Player—haracteristics player—haracteristics;
    [Header("Bomb settings")]
    [SerializeField] private int bombCount;
    [SerializeField] private int bombLifeTime;
    [Header("Level Generator")]
    [SerializeField] private int minAmountOfRooms;
    [SerializeField] private int maxAmountOfRooms;
    [Header("Other")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private BombSystem bombSystem;
    [SerializeField] private Transform heartsParent;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject bossRoomPrefab;
    [SerializeField] private GameObject goldenRoomPrefab;

    private SmartLevelGenerator smartLevelGenerator;
    void Start()
    {
        BulletPool bulletPool = new BulletPool(10, bulletPrefab);
        bombSystem.Construct(playerTransform, bombPrefab, bombCount, bombLifeTime);
        HealthSystem healthSystem = new HealthSystem(player—haracteristics.Health, heartsParent);
        inputListener.Construct(player—haracteristics.PlayerSpeed,
                            playerRb, 
                            head,
                            player—haracteristics.ShootSpeed, 
                            player—haracteristics.BulletSpeed, 
                            bombSystem,
                            bulletPool);
        //LevelGenerator levelGenerator = new LevelGenerator(roomPrefabOne, roomPrefabSecond);
        smartLevelGenerator = new SmartLevelGenerator(minAmountOfRooms, maxAmountOfRooms, roomPrefab, bossRoomPrefab, goldenRoomPrefab);
    }

    private void Update()
    {
        smartLevelGenerator.Generate();
    }
}
