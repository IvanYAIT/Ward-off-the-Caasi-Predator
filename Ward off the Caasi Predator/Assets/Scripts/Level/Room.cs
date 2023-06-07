using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask bossRoomLayerMask;
    [SerializeField] private LayerMask goldenRoomLayerMask;
    [SerializeField] private Transform doorsParent;

    private int _index;
    private int[] _doors;

    private int _playerLayer;
    private int _bossRoomLayer;
    private int _goldenRoomLayer;

    private void Start()
    {
        _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        _bossRoomLayer = (int)Mathf.Log(bossRoomLayerMask.value, 2);
        _goldenRoomLayer = (int)Mathf.Log(goldenRoomLayerMask.value, 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer != _playerLayer)
            gameObject.SetActive(false);
    }

    public void Construct(int index, int[] doors)
    {
        _index = index;
        _doors = doors;
        CreateDoors();
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
