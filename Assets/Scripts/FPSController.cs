 using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float staminaDrainPerSecond = 1.0f;
    public float maxStamina = 5.0f;
    public float outOfStaminaCooldownDuration = 2.0f; //how long you cant sprint if out of breath sound cue is triggered
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public GameObject flashlight;
    private bool _isFlashlightOn = false;
    private float _staminaValue = 5.0f;
    public AudioSource antiBear;
    public AudioSource outOfBreath;
    public AudioSource walkingNoise;


    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    private bool canMove = true;

    public bool IsFlashlightOn { get => _isFlashlightOn; set => _isFlashlightOn = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public float StaminaValue { get => _staminaValue; set => _staminaValue = value; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float movementDirectionY = moveDirection.y;
        if (Input.GetKey(KeyCode.F) && StaminaValue>= maxStamina && !antiBear.isPlaying)
        {
            antiBear.Play();
            StaminaValue = 0.0f;
        }
        // Hard coded to left shift TODO: change to keybind, thats changeable
        bool isRunning = StaminaValue > 0.0f  && Input.GetKey(KeyCode.LeftShift);
        
        float curSpeedX = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        if (StaminaValue<=0.0f && !outOfBreath.isPlaying)
        {
            if (antiBear.isPlaying)
            {
                outOfBreath.PlayDelayed(2.5f);
            }
            else
            {
                outOfBreath.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            IsFlashlightOn = !IsFlashlightOn;
            flashlight.SetActive(IsFlashlightOn);
        }
        // Player and Camera rotation
        if (CanMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if(isRunning && StaminaValue > 0.0f && (curSpeedX > 0.0f || curSpeedY > 0.0f))
        {
            StaminaValue -= Time.deltaTime;
        }
        else if (!isRunning)
        {
            if (StaminaValue < maxStamina)
            {
                StaminaValue += Time.deltaTime * 0.5f;
            }
        }
    }

}