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
    public Transform zomCombie;

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

    IEnumerator spawnEnemy(float time)
    {
        
        yield return new WaitForSeconds(time);
        
        
    }
    void Update()
    {
        // if (zomCombie.childCount > 9)
        // {  
        //     spawner.Return(zomCombie.transform.GetChild(1).gameObject);
        // }
        // StartCoroutine(spawnEnemy(3f));
        // var go = spawner.Get(typeOfZom.ToString(), Vector3.zero, quaternion.identity);
        // go.SetActive(true);
        // go.transform.parent = zomCombie;
    }

    public void SpawnPress()
    {
        if (this.transform.childCount < 0)
        {
            return;
        }
        var go = spawner.Get(typeOfZom.ToString(), Vector3.zero, quaternion.identity);
        go.SetActive(true);
        go.transform.SetParent(zomCombie);
        
    }

    public void ReturnPress()
    {
       
        spawner.Return(zomCombie.GetChild(0).gameObject);
    }
}
