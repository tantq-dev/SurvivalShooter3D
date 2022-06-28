using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPlayer : MonoBehaviour
{
    public float speed;
    public GameObject playerPosition;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        playerPosition = GameObject.Find("Player");
        _animator = GetComponent<Animator>();    }

    private void Update()
    {
        speed = _navMeshAgent.velocity.magnitude;
        _animator.SetFloat("Speed",Mathf.Sqrt(speed));
        _navMeshAgent.destination=playerPosition.gameObject.transform.position;
    }
}
