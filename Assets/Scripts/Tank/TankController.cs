using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    //Event to trigger pause menu
    [HideInInspector] public UnityEvent OnPauseMenu;
    bool bIsOnPause = false;

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
        if(context.started) //Button pressed
        {
            IdleSound.Stop();
            MovementSound.Play();
        }
        else if(context.canceled) //Button released
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
        if(context.performed && !bIsOnPause)
        {
            WH.UseWeapon();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            bIsOnPause = !bIsOnPause;
            OnPauseMenu.Invoke();
        }
    }

    #endregion

    #region TriggerEffects

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Turbo")) //Check effector
        {
            ApplyTurbo(); //Velocity increment

        }
        else if(other.CompareTag("Ammo"))
        {
            PickingAmmoSound.Play(); //Add 5 projectiles to current ammo
            WH.OnEffectorAddAmmo();
        }
        else if(other.CompareTag("Multishot"))
        {
            WH.OnEffectorMultishotWeapon(); //Makes weapon miltishoot for 8 secs
        }
        else
        {
            return;
        }

        Destroy(other.gameObject);
        GameManager.Instance.GetComponent<EffectorsManager>().EnableTimerToSpawnNewEffector(); //Event to spawn new effector
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
