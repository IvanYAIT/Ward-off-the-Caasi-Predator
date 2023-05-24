using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private int[,] level;

    public LevelGenerator()
    {
        level = new int[101,101];

        InitLevel();
        CreateLevel();
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
                        for (int g = 0; g < amountOfRooms; g++)
                        {

                        }
                    }
                }
            }
        }
        
    }

    private void InitLevel()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (i == level.GetLength(0) / 2 && j == level.GetLength(1) / 2)
                    level[i, j] = 1;
                else
                    level[i, j] = 0;
            }
        }
    }

    
}