using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //Input system
    private TankControls InputMapping;
    private PlayerInput Controls;

    // Character Attributes
    [Header("Character Attributes")]
    [SerializeField] private float BaseMovementSpeed = 6;
    [SerializeField] private float BaseChassisRotationSpeed = 16;
    [SerializeField] private float TurretRotationSpeed = 25;

    [Header("Sounds")]
    [SerializeField] private AudioSource IdleSound;
    [SerializeField] private AudioSource MovementSound;
    [SerializeField] private AudioSource PickingAmmoSound;

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
        Controls = GetComponent<PlayerInput>();
        WH = GetComponentInChildren<WeaponHandler>();
        CurrentMovementSpeed = BaseMovementSpeed;
        CurrentChassisRotationSpeed = BaseChassisRotationSpeed;
    }

    void Start()
    {
        IdleSound.Play();
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
        if(context.started)
        {
            IdleSound.Stop();
            MovementSound.Play();
        }
        else if(context.canceled)
        {
            MovementSound.Stop();
            IdleSound.Play();
        }

        MovementInputMultiplier = context.ReadValue<float>();
        CalculateNewMovement();

    }

    private void CalculateNewMovement()
    {
        Movement = MovementInputMultiplier * CurrentMovementSpeed * Time.fixedDeltaTime;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        TankRotationInputMultiplier = context.ReadValue<float>();
        CalculateNewTankRotation();
        //TurretRotation = 0;
    }

    private void CalculateNewTankRotation()
    {
        TankRotation = TankRotationInputMultiplier * CurrentChassisRotationSpeed * Time.fixedDeltaTime;
    }

    public void OnRotateCannon(InputAction.CallbackContext context)
    {
        TurretRotation = context.ReadValue<float>() * TurretRotationSpeed * Time.fixedDeltaTime;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            WH.UseWeapon();
        }
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
            PickingAmmoSound.Play();
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
