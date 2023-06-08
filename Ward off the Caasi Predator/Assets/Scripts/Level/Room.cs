using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask bossRoomLayerMask;
    [SerializeField] private LayerMask goldenRoomLayerMask;
    [SerializeField] private Transform doorsParent;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private bool isSpecial;

    [SerializeField] private GameObject pickableObject;
    [SerializeField] private Transform pickableObjectSpawnPoint;

    public int Index { get; private set; }

    private int[] _doors;
    private int _bossRoomLayer;
    private int _goldenRoomLayer;
    private int _playerLayer;
    private bool isDoorsSet;
    private bool isPickableObjectSpawn;

    private void Start()
    {
        _bossRoomLayer = (int)Mathf.Log(bossRoomLayerMask.value, 2);
        _goldenRoomLayer = (int)Mathf.Log(goldenRoomLayerMask.value, 2);
        _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
    }

    private void Update()
    {
        if(enemyParent.childCount <= 0 && isDoorsSet)
        {
            CreateDoors();
            if (!isSpecial && !isPickableObjectSpawn)
            {
                Instantiate(pickableObject, pickableObjectSpawnPoint.position, Quaternion.identity);
                isPickableObjectSpawn = true;
            }
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _playerLayer)
        {
            CameraMover.OnMove?.Invoke(new Vector3(transform.position.x, transform.position.y, -10));
            for (int i = 0; i < enemyParent.childCount; i++)
            {
                enemyParent.GetChild(i).gameObject.SetActive(true);
            }
        }
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _bossRoomLayer || collision.gameObject.layer == _goldenRoomLayer)
            gameObject.SetActive(false);
    }

    public void Construct(int index)
    {
        Index = index;
    }

    public void SetDoors(int[] doors)
    {
        _doors = doors;
        isDoorsSet = true;
    }

    private void CreateDoors()
    {
        if (_doors[0] == 1)
            doorsParent.GetChild(0).gameObject.SetActive(true);
        if (_doors[1] == 1)
            doorsParent.GetChild(1).gameObject.SetActive(true);
        if (_doors[2] == 1)
            doorsParent.GetChild(2).gameObject.SetActive(true);
        if (_doors[3] == 1)
            doorsParent.GetChild(3).gameObject.SetActive(true);
    }
}
