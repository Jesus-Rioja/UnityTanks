using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //Input system
    private TankControls InputMapping;

    // Character Attributes
    [Header("Character Attributes")]
    [SerializeField] private float movementSpeed = 6;
    [SerializeField] private int life = 1;

    //Components
    private Rigidbody Rb;

    //Movement variables
    private Vector3 movement = Vector3.zero;

    private void Awake()
    {
        InputMapping = new TankControls();
        Rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        InputMapping.TankInput.Move.performed += OnMove;
        InputMapping.TankInput.Move.canceled += OnMove;
    }

    private void OnEnable()
    {
        InputMapping.Enable();
    }

    private void OnDisable()
    {
        InputMapping.Disable();
    }

    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    #region TankActions

    public void OnMove(InputAction.CallbackContext context)
    {
        //if (action == Action.PLANTING && context.phase != InputActionPhase.Started) return;
        Vector2 inputVector = context.ReadValue<Vector2>();
        movement = new Vector3(inputVector.x, 0, inputVector.y);

        if (movement.magnitude <= 0.5f)
            movement = Vector3.zero;

    }

    #endregion
}
