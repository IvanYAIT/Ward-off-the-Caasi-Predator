using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator
{
    private GameObject _roomPrefab;
    private int _maxRooms;

    public RoomGenerator(GameObject roomPrefab, int maxRooms)
    {
        _maxRooms = maxRooms;
        _roomPrefab = roomPrefab;
    }

    public void Generate(int roomCount, RoomGenerator roomGenerator,Room currentRoom,Transform currrentRoomTranform, out Room[] rooms)
    {
        if(roomCount < _maxRooms-1)
        {
            GameObject obj = Object.Instantiate(_roomPrefab, currrentRoomTranform.position + Vector3.right * 16, Quaternion.identity);
            Room nextRoom = obj.GetComponent<Room>();
            roomCount++;
            nextRoom.Construct(roomCount, roomGenerator);
            rooms = new Room[] { nextRoom };
        }else
            rooms = null;
    }
}
