using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float hp;

    private float _currentHp;
    private int _playerLayer;
    private GameObject _player;
    private NavMeshAgent _agent;
    private bool onCooldown;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        _currentHp = hp;
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
            if(!onCooldown)
                StartCoroutine(Attack(collision));
    }

    private IEnumerator Attack(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().GetDamage();
        onCooldown = true;
        yield return new WaitForSeconds(1);
        onCooldown = false;
    }

    public void GetDamage(float damage)
    {
        _currentHp -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHp <= 0)
            Death();
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
