using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Room UpRoom { get; private set; }
    public Room DownRoom { get; private set; }
    public Room RightRoom { get; private set; }
    public Room LeftRoom { get; private set; }

    private int _roomCount;
    private RoomGenerator _roomGenerator;

    private void NextRooms()
    {
        Room[] rooms;
        _roomGenerator.Generate(_roomCount, _roomGenerator,this,transform, out rooms);
    }

    public void Construct(int roomCount, RoomGenerator roomGenerator)
    {
        _roomCount = roomCount;
        _roomGenerator = roomGenerator;
        NextRooms();
    }
}
