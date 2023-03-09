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
    [SerializeField] private float MovementSpeed = 6;
    [SerializeField] private float ChassisRotationSpeed = 16;
    [SerializeField] private float TurretRotationSpeed = 25;
    [SerializeField] private int Life = 1;

    //TankComponents
    [SerializeField] private Transform TankTurret;

    //Movement variables
    private float Movement = 0;
    private float TankRotation = 0;
    private float TurretRotation = 0;

    private void Awake()
    {
        InputMapping = new TankControls();
    }

    void Start()
    {
        InputMapping.TankInput.Move.performed += OnMove;
        InputMapping.TankInput.Move.canceled += OnMove;

        InputMapping.TankInput.Rotate.performed += OnRotateTank;
        InputMapping.TankInput.Rotate.canceled += OnRotateTank;

        InputMapping.TankInput.RotateCannon.performed += OnRotateTurret;
        InputMapping.TankInput.RotateCannon.canceled += OnRotateTurret;
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
        transform.Translate(0, 0, Movement);
        transform.Rotate(0, TankRotation, 0);

        TankTurret.Rotate(0, TurretRotation, 0);
    }

    #region TankActions

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<float>() * MovementSpeed * Time.fixedDeltaTime;
    }

    public void OnRotateTank(InputAction.CallbackContext context)
    {
        TankRotation = context.ReadValue<float>() * ChassisRotationSpeed * Time.fixedDeltaTime;
        TurretRotation = 0;
    }

    public void OnRotateTurret(InputAction.CallbackContext context)
    {
        TurretRotation = context.ReadValue<float>() * TurretRotationSpeed * Time.fixedDeltaTime;
    }

    #endregion
}
