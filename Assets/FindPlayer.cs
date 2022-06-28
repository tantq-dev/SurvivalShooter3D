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

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        playerPosition = GameObject.Find("Player");
    }

    private void Update()
    {
        speed = _navMeshAgent.velocity.magnitude;
        _navMeshAgent.destination=playerPosition.gameObject.transform.position;
    }
}
