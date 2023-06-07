using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask bulletLayerMask;

    private int _bulletLayer;
    private GameObject _player;
    private NavMeshAgent _agent;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _bulletLayer = (int)Mathf.Log(bulletLayerMask.value, 2);
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _bulletLayer)
            Destroy(gameObject);
    }
}
