using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponShot : MonoBehaviour
{
    public ParticleSystem shootPartical;
    public AudioClip shootSound;
    public float range =10f;
    public Transform gunBarrel;
    public float damage;
    public AudioSource _audioSource;
    [FormerlySerializedAs("LineRenderer")] public LineRenderer lineRenderer;

    public void Shoot() 
    {
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out var hitInfo, range))
        {
            Debug.Log("Hit "+hitInfo.collider.name);
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
                hitInfo.collider.gameObject.GetComponent<EnemyAbilities>().TakeDame(damage);
            }
        }
        var position1 = gunBarrel.position;
        var position = position1;
        lineRenderer.SetPosition(0,position);
        lineRenderer.SetPosition(1,position1+gunBarrel.forward*10);
        _audioSource.clip = shootSound;
        _audioSource.Play();
        shootPartical.Play();
        lineRenderer.enabled = true;
        StartCoroutine(Wait(0.1f));
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        lineRenderer.enabled = false;
    }
}
