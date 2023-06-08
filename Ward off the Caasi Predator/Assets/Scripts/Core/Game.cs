using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game
{
    public static Action OnEnd;

    public Game()
    {
        OnEnd += End;
    }

    public void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnEnd -= End;
    }
}
