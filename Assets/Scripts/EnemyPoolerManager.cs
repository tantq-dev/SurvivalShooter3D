using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pooling;

public class EnemyPoolerManager : MonoBehaviour
{
    [SerializeField] private GameObjectSpawner spawner;
    public float timeToSpawn;
    private float _elapsedTime =0f;
    public Transform spawnPoint;
    public enum TypeOfZom
    {
        ephant,
        bear,
        bunny
    }

    public TypeOfZom typeOfZom;
    void Start()
    {
        spawner.Initialize();
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > timeToSpawn)
        {
            SpawnEnemy();
            _elapsedTime = 0f;
        }
    }

    public void SpawnPress()
    {
        if (this.transform.childCount < 0)
        {
            return;
        }

    }
    private void SpawnEnemy()
    {
        var go = spawner.Get(typeOfZom.ToString(), Vector3.zero, quaternion.identity);
        go.transform.position = spawnPoint.transform.position;
        go.GetComponent<EnemyAbilities>().OriginWhenSpawn();
        go.transform.SetParent(this.transform);
    }

   
}
