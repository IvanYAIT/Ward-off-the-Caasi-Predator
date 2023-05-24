using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private Player—haracteristics player—haracteristics;
    [Header("Level Settings")]
    [SerializeField] private int maxRooms;
    [Header("Bomb settings")]
    [SerializeField] private int bombCount;
    [SerializeField] private int bombLifeTime;
    [Header("Other")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private BombSystem bombSystem;
    [SerializeField] private Transform heartsParent;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Room startRoom;
    [SerializeField] private GameObject roomPrefab;

    void Start()
    {
        BulletPool bulletPool = new BulletPool(10);
        bombSystem.Construct(playerTransform, bombPrefab, bombCount, bombLifeTime);
        RoomGenerator roomGenerator = new RoomGenerator(roomPrefab, maxRooms);
        startRoom.Construct(0, roomGenerator);
        HealthSystem healthSystem = new HealthSystem(player—haracteristics.Health, heartsParent);
        inputListener.Construct(player—haracteristics.PlayerSpeed,
                            playerRb, 
                            head, 
                            bulletPrefab, 
                            player—haracteristics.ShootSpeed, 
                            player—haracteristics.BulletSpeed, 
                            bombSystem,
                            bulletPool);
    }
}
