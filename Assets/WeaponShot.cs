using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponShot : MonoBehaviour
{
    public float range =10f;
    public Transform gunBarrel;
    [FormerlySerializedAs("LineRenderer")] public LineRenderer lineRenderer;
    public void Shoot()
    {
        /*RaycastHit hitInfo;
        if (Physics.Raycast(gunBarrel, gunBarrel.forward, out hitInfo, range))
        {
            if (hitInfo.collider != null)
            {
                
            }
        }*/
        var position1 = gunBarrel.position;
        var position = position1;
        lineRenderer.SetPosition(0,position);
        lineRenderer.SetPosition(1,position1+gunBarrel.forward*10);
        lineRenderer.enabled = true;
        StartCoroutine(Wait(0.2f));
        
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        lineRenderer.enabled = false;
    }
}
