using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private Player—haracteristics player—haracteristics;
    [Header("Bomb settings")]
    [SerializeField] private int bombCount;
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
    [SerializeField] private GameObject startRoomPrefab;
    [SerializeField] private GameObject bossRoomPrefab;
    [SerializeField] private GameObject goldenRoomPrefab;
    [SerializeField] private NavMeshSurface Surface2D;
    [SerializeField] private Player player;

    private SmartLevelGenerator smartLevelGenerator;

    void Start()
    {
        Game game = new Game();
        BulletPool bulletPool = new BulletPool(10, bulletPrefab);
        bombSystem.Construct(playerTransform, bombPrefab, bombCount);
        HealthSystem healthSystem = new HealthSystem(player—haracteristics.Health, heartsParent);
        player.Construct(healthSystem);
        inputListener.Construct(player—haracteristics.PlayerSpeed,
                            playerRb, 
                            head,
                            player—haracteristics.ShootSpeed,
                            player—haracteristics.BulletSpeed,
                            player—haracteristics.Damage,
                            bombSystem,
                            bulletPool);
        smartLevelGenerator = new SmartLevelGenerator(minAmountOfRooms, maxAmountOfRooms, roomPrefab, startRoomPrefab, bossRoomPrefab, goldenRoomPrefab, Surface2D);
    }

    private void Update()
    {
        smartLevelGenerator.Generate();
    }
}
