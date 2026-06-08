using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    [SerializeField] private Vector2 _playerPosition;
    private Rigidbody2D _playerRB;
    public float _playerSpeed;

    private void OnEnable()
    {
        _inputActions.Enable(); 
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    void PlayerInput()
    {
        _playerPosition = _inputActions.Player.Move.ReadValue<Vector2>();
    }
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();          
    }

    private void FixedUpdate()
    {
        PlayerMove();   
    }

    void PlayerMove()
    {
        _playerRB.MovePosition( _playerRB.position + _playerPosition * (_playerSpeed * Time.deltaTime));
    }
}
