using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static Action<Vector3> OnMove;

    private void Start()
    {
        OnMove += Move;
    }

    private void Move(Vector3 position)
    {
        transform.position = position;
    }

    private void OnDestroy()
    {
        OnMove -= Move;
    }
}
