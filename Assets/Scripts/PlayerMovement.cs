using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Pooling;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3Variable position;
    [SerializeField] private IntVariable playerHp;
    [SerializeField] private IntVariable maxHP;
    public UnityEvent DeathEvent;
    private PlayerInputAction _playerInput;
    public CharacterController playerController;
    private Camera _cam;
    
    public Vector2 moveDirection = Vector2.zero;
    private InputAction _move;
    public Animator playerAnim;
    public float Speed;

    private void Awake()
    {
        playerHp.Value = maxHP.Value;
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
//        Debug.Log(currentHealth);
        if (playerHp.Value < 0.1)
        {
            Death();
        }
        this.moveDirection = _move.ReadValue<Vector2>();
        playerAnim.SetFloat("Speed", Mathf.Sqrt(this.moveDirection.magnitude));
        Vector3 moveDirection = new Vector3(this.moveDirection.x, 0, this.moveDirection.y);
        playerController.Move(moveDirection * (Time.deltaTime * Speed));
        position.Value = transform.position;
        Ray cameraRay = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(cameraRay, out var rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    private void Death()
    {
       // _audioSource.clip = deathSound;
      //  _audioSource.Play();
      
        playerAnim.SetTrigger("Death");
        DeathEvent.Invoke();
    }
}