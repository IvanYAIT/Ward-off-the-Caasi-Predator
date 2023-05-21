using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int _currentMaxHealth;
    private int _currentHealth;
    private List<Transform> _hearts;

    public HealthSystem(int currentMaxHealth, Transform heartsParent)
    {
        _currentMaxHealth = currentMaxHealth;
        _currentHealth = currentMaxHealth;
        _hearts = new List<Transform>();
        for (int i = 0; i < heartsParent.childCount; i++)
            _hearts.Add(heartsParent.GetChild(i));
        for (int i = 0; i < currentMaxHealth; i++)
            _hearts[i].gameObject.SetActive(true);
    }

    public void GetDamage()
    {
        if(_currentHealth != 0)
        {
            _currentHealth--;
            _hearts[_currentHealth].gameObject.SetActive(false);
        }
    }

    public void HealHeart()
    {
        if(_currentMaxHealth != _currentHealth)
        {
            _hearts[_currentHealth].gameObject.SetActive(true);
            _currentHealth++;
        }
    }

    public void IncreaseMaxHealth()
    {
        Debug.Log("aaaaaaaa");
        if (_currentMaxHealth != _hearts.Count)
        {
            _currentMaxHealth++;
            Debug.Log(_currentMaxHealth);
        }
    }

    public void DecreaseMaxHealth()
    {
        if(_currentMaxHealth != 1)
        {
            _currentMaxHealth--;
            if(_currentMaxHealth < _currentHealth)
            {
                _currentHealth--;
                _hearts[_currentHealth].gameObject.SetActive(false);
            }
        }
    }
}
