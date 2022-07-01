using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public float TimeToDisable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableMe()
    {
        StartCoroutine(WaitToDestroy(TimeToDisable));
    }
    IEnumerator WaitToDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
