using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pooling;

public class EnemyReturnToPool : MonoBehaviour
{
    public bool isDeath;
   [SerializeField]private GameObjectSpawner spawner;
    void Awake()
    {
       spawner = GetComponentInParent<GameObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            spawner.Return(this.gameObject);
        }
    }
}
