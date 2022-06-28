using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputAction _playerInput;
    public CharacterController playerController;
    private Camera _cam;
    public Vector2 moveDirection = Vector2.zero;
    private InputAction _move;
    public Animator playerAnim;
    public float Speed;

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
        playerAnim.SetFloat("Speed", Mathf.Sqrt(this.moveDirection.magnitude));
        Vector3 moveDirection = new Vector3(this.moveDirection.x, 0, this.moveDirection.y);
        playerController.Move(moveDirection * (Time.deltaTime * Speed));
        Ray cameraRay = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(cameraRay, out var rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}