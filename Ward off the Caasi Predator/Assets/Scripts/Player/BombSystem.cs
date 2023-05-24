using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSystem : MonoBehaviour
{
    private Transform _player;
    private GameObject _bombPrefab;
    private int _bombLifeTime;

    private int _currentAmountBomb;

    public void Construct(Transform player, GameObject bombPrefab, int bombCount, int bombLifeTime)
    {
        _player = player;
        _bombPrefab = bombPrefab;
        _currentAmountBomb = bombCount;
        _bombLifeTime = bombLifeTime;
    }

    public void UseBomb()
    {
        if(_currentAmountBomb > 0)
        {
            GameObject obj = Instantiate(_bombPrefab, _player.position, Quaternion.identity);
            _currentAmountBomb--;
            StartCoroutine(BombLife(obj));
        }
    }    

    private IEnumerator BombLife(GameObject obj)
    {
        yield return new WaitForSeconds(_bombLifeTime);
        Destroy(obj);
    }
}
