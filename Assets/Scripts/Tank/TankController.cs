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
    [SerializeField] private float BaseMovementSpeed = 6;
    [SerializeField] private float BaseChassisRotationSpeed = 16;
    [SerializeField] private float TurretRotationSpeed = 25;

    //TankComponents
    [SerializeField] private Transform TankTurret;

    //Movement variables
    private float Movement = 0;
    private float MovementInputMultiplier = 0;
    private float CurrentMovementSpeed = 0;
    private float TankRotation = 0;
    private float TankRotationInputMultiplier = 0;
    private float CurrentChassisRotationSpeed = 0;
    private float TurretRotation = 0;
    private float TurboDuration = 10.0f;
    private float TurboTimeRemaining = 0f;

    //Weapon manager
    private WeaponHandler WH;

    private void Awake()
    {
        InputMapping = new TankControls();
        WH = GetComponentInChildren<WeaponHandler>();
        CurrentMovementSpeed = BaseMovementSpeed;
        CurrentChassisRotationSpeed = BaseChassisRotationSpeed;
    }

    void Start()
    {
        GameManager.Instance.CurrentPlayers.Add(this.gameObject);

        //Binds every input action to a function
        InputMapping.TankInput.Move.performed += OnMove;
        InputMapping.TankInput.Move.canceled += OnMove;

        InputMapping.TankInput.Rotate.performed += OnRotateTank;
        InputMapping.TankInput.Rotate.canceled += OnRotateTank;

        InputMapping.TankInput.RotateCannon.performed += OnRotateTurret;
        InputMapping.TankInput.RotateCannon.canceled += OnRotateTurret;

        InputMapping.TankInput.Attack.performed += OnAttack;
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

        if(TurboTimeRemaining > 0) //On turbo
        {
            TurboTimeRemaining -= Time.fixedDeltaTime;
        }
        else if(BaseMovementSpeed != CurrentMovementSpeed) //If turbo ended, reset movement speed values
        {
            CurrentMovementSpeed = BaseMovementSpeed;
            CalculateNewMovement();

            CurrentChassisRotationSpeed = BaseChassisRotationSpeed;
            CalculateNewTankRotation();
        }

    }

    #region TankActions

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementInputMultiplier = context.ReadValue<float>();
        CalculateNewMovement();
    }

    private void CalculateNewMovement()
    {
        Movement = MovementInputMultiplier * CurrentMovementSpeed * Time.fixedDeltaTime;
    }

    public void OnRotateTank(InputAction.CallbackContext context)
    {
        TankRotationInputMultiplier = context.ReadValue<float>();
        CalculateNewTankRotation();
        //TurretRotation = 0;
    }

    private void CalculateNewTankRotation()
    {
        TankRotation = TankRotationInputMultiplier * CurrentChassisRotationSpeed * Time.fixedDeltaTime;
    }

    public void OnRotateTurret(InputAction.CallbackContext context)
    {
        TurretRotation = context.ReadValue<float>() * TurretRotationSpeed * Time.fixedDeltaTime;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        WH.UseWeapon();
    }

    #endregion

    #region TriggerEffects

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Turbo")) //Check effector
        {
            ApplyTurbo();

        }
        else if(other.CompareTag("Ammo"))
        {
            GetComponentInChildren<WeaponHandler>().OnEffectorAddAmmo();
        }
        else
        {
            return;
        }

        Destroy(other.gameObject);
        GameManager.Instance.GetComponent<EffectorsManager>().EnableTimerToSpawnNewEffector();
    }

    private void ApplyTurbo()
    {
        if(TurboTimeRemaining <= 0) //Increase the movement speed of the tank
        {
            CurrentMovementSpeed = BaseMovementSpeed * 1.5f;
            CalculateNewMovement();

            CurrentChassisRotationSpeed = BaseChassisRotationSpeed * 2;
            CalculateNewTankRotation();
        }
        TurboTimeRemaining = TurboDuration;
    }

    #endregion
}
