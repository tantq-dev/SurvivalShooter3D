using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputAction _playerInput;
    public CharacterController playerController;
    private Camera _cam;
    public Vector2 moveDirection = Vector2.zero;
    private InputAction _move;

    private void Awake()
    {
        _playerInput = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _move = _playerInput.Player.Movement;
        _move.Enable();
    }

    private void OnDisable()
    {
        _move.Disable();
    }

    void Start()
    {
        _cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.moveDirection = _move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(this.moveDirection.x, 0, this.moveDirection.y);
        playerController.Move(moveDirection * Time.deltaTime);
        Ray cameraRay = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;
        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}