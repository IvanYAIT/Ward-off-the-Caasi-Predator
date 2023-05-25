using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    Right,
    Left,
    Up,
    Down
}

public class LevelGenerator
{
    private const int HEIGTH = 16;
    private const int WIDTH = 8;

    private int[,] level;
    private GameObject _roomPrefabOne;
    private GameObject _roomPrefabSecond;

    public LevelGenerator(GameObject roomPrefabOne, GameObject roomPrefabSecond)
    {
        _roomPrefabOne = roomPrefabOne;
        _roomPrefabSecond = roomPrefabSecond;
        level = new int[101,101];

        InitLevel();
        CreateLevel();
        SpawnRoom();
    }

    private void InitLevel()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (i == level.GetLength(0) / 2 && j == level.GetLength(1) / 2)
                {
                    level[i, j] = 2;
                    level[i + 1, j] = 1;
                    level[i - 1, j] = 1;
                    level[i, j + 1] = 1;
                    level[i, j - 1] = 1;
                }
            }
        }
    }

    private void CreateLevel()
    {
        for (int k = 0; k < 10; k++)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    if (level[i,j] == 1)
                    {
                        int amountOfRooms = UnityEngine.Random.Range(1,4);
                        List<Direction> directions = new List<Direction>() { Direction.Right, Direction.Left, Direction.Up, Direction.Down };
                        List<Direction> removedDirections = new List<Direction>();

                        for (int g = 0; g < 4-amountOfRooms; g++)
                        {
                            int rnd = UnityEngine.Random.Range(0, directions.Count);
                            removedDirections.Add(directions[rnd]);
                            directions.RemoveAt(rnd);
                        }

                        foreach (Direction item in directions)
                        {
                            switch (item)
                            {
                                case Direction.Right:
                                    if(level[i, j + 1] == 0)
                                        level[i, j + 1] = 5;
                                    break;
                                case Direction.Left:
                                    if(level[i, j - 1] == 0)
                                        level[i, j - 1] = 5;
                                    break;
                                case Direction.Down:
                                    if(level[i + 1, j] == 0)
                                        level[i+1, j] = 5;
                                    break;
                                case Direction.Up:
                                    if(level[i - 1, j] == 0)
                                        level[i-1, j] = 5;
                                    break;
                            }
                        }

                        foreach (Direction item in removedDirections)
                        {
                            switch (item)
                            {
                                case Direction.Right:
                                    if (level[i, j + 1] == 0)
                                        level[i, j + 1] = -1;
                                    break;
                                case Direction.Left:
                                    if (level[i, j - 1] == 0)
                                        level[i, j - 1] = -1;
                                    break;
                                case Direction.Down:
                                    if (level[i + 1, j] == 0)
                                        level[i + 1, j] = -1;
                                    break;
                                case Direction.Up:
                                    if (level[i - 1, j] == 0)
                                        level[i - 1, j] = -1;
                                    break;
                            }
                        }
                        level[i, j] = 2;
                    }
                }
            }
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    if (level[i, j] == 5)
                        level[i, j] = 1;
                }
            }
        }
        
    }

    private void SpawnRoom()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if(level[i,j] == 1)
                {
                    GameObject.Instantiate(_roomPrefabOne, new Vector2((i - (level.GetLength(0)-1)/2)*HEIGTH, (j - (level.GetLength(1)-1)/2)*WIDTH), Quaternion.identity);
                } else if (level[i, j] == 2)
                    GameObject.Instantiate(_roomPrefabSecond, new Vector2((i - (level.GetLength(0) - 1) / 2) * HEIGTH, (j - (level.GetLength(1) - 1) / 2) * WIDTH), Quaternion.identity);
            }
        }
    }
}