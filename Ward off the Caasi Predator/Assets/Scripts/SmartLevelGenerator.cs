using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartLevelGenerator
{
    private const int HEIGTH = 16;
    private const int WIDTH = 8;

    private int _minAmountOfRooms;
    private int _maxAmountOfRooms;
    private int _currentAmountOfRooms;
    private int[] _level;
    private List<int> _endRooms;
    private Queue<int> _roomQueue;
    private bool _started;
    private bool _placedSpecial;
    private GameObject _roomPrefab;
    private GameObject _goldenRoomPrefab;
    private GameObject _bossRoomPrefab;

    public SmartLevelGenerator(int minAmountOfRooms, int maxAmountOfRooms, GameObject roomPrefab, GameObject bossRoomPrefab, GameObject goldenRoomPrefab)
    {
        _bossRoomPrefab = bossRoomPrefab;
        _goldenRoomPrefab = goldenRoomPrefab;
        _roomPrefab = roomPrefab;
        _minAmountOfRooms = minAmountOfRooms;
        _maxAmountOfRooms = maxAmountOfRooms;
        Start();
    }

    private void Start()
    {
        _started = true;
        _level = new int[100];
        _endRooms = new List<int>();
        _roomQueue = new Queue<int>();
        Visit(45);
    }

    private bool Visit(int roomIndex)
    {
        if (_level[roomIndex] == 1)
            return false;

        if (NeighbourCount(roomIndex) > 1)
            return false;

        if (_currentAmountOfRooms > _maxAmountOfRooms)
            return false;

        System.Random rnd = new System.Random();
        if (rnd.NextDouble() < 0.5 && roomIndex != 45)
            return false;

        _roomQueue.Enqueue(roomIndex);
        _level[roomIndex] = 1;
        _currentAmountOfRooms++;
        CreateRoom(roomIndex, _roomPrefab);
        return true;
    }

    public void Generate()
    {
        if (_started)
        {
            if(_roomQueue.Count > 0)
            {
                int i = _roomQueue.Dequeue();
                int x = i % 10;
                bool created = false;
                if (x > 1)
                    created = Visit(i - 1);
                if (x < 9)
                    created = Visit(i + 1);
                if (i > 20)
                    created = Visit(i - 10);
                if (i < 70)
                    created = Visit(i + 10);
                if (!created)
                {
                    if(NeighbourCount(i) <= 1)
                        _endRooms.Add(i);
                }
                    
            }
            else if(!_placedSpecial) 
            {
                if (_currentAmountOfRooms < _minAmountOfRooms)
                {
                    Start();
                    return;
                }
                _placedSpecial = true;
                int bossRoom = _endRooms[_endRooms.Count - 1];
                _endRooms.RemoveAt(_endRooms.Count - 1);
                CreateRoom(bossRoom, _bossRoomPrefab);

                int goldenRoom = RandomRoom();
                CreateRoom(goldenRoom, _goldenRoomPrefab);
                Debug.Log(_endRooms.Count);
            }
        } 
    }

    private int NeighbourCount(int roomIndex) =>
        _level[roomIndex + 1] + _level[roomIndex - 1] + _level[roomIndex + 10] + _level[roomIndex - 10];

    private int RandomRoom()
    {
        System.Random rnd = new System.Random();
        int index = (int)Math.Floor(rnd.NextDouble() * _endRooms.Count);
        int i = _endRooms[index];
        _endRooms.RemoveAt(index);
        return i;
    }

    private void CreateRoom(int roomIndex, GameObject prefab)
    {
        int x = ((roomIndex % 10) - (_level.Length/4)) * HEIGTH;
        int y = ((roomIndex / 10) - (_level.Length / 4)) * WIDTH;

        GameObject.Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
    }
}
