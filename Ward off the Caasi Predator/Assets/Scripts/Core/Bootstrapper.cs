using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private int health;
    [SerializeField] private float damage;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float bulletSpeed;
    [Header("Level Settings")]
    [SerializeField] private int maxRooms;
    [Header("Other")]
    [SerializeField] private Transform heartsParent;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Room startRoom;
    [SerializeField] private GameObject roomPrefab;

    void Start()
    {
        RoomGenerator roomGenerator = new RoomGenerator(roomPrefab, maxRooms);
        startRoom.Construct(0, roomGenerator);
        HealthSystem healthSystem = new HealthSystem(health, heartsParent);
        inputListener.Construct(playerSpeed, rb, head, bulletPrefab, shootSpeed, bulletSpeed);
    }
}
