using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInputAction _controls;
    
    public WeaponShot weapon;
    private void Awake()
    {
        _controls = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        _controls.Player.Fire.performed += _ => weapon.Shoot();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Debug.Log("Shooting");
    }
}
