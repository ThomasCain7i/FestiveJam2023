using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [SerializeField] GameObject blueprintCanvas, inventoryCanvas;
    [SerializeField] bool blueprintActive;

    // Ground Sounds:
    public AudioClip[] woodFootstepSounds;
    public Transform footstepAudioPosition;
    public AudioSource audioSource;

    private bool isWalking = false;
    private bool isFootstepCoroutineRunning = false;
    private AudioClip[] currentFootstepSounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        blueprintCanvas.SetActive(true);
        inventoryCanvas.SetActive(false);

        blueprintActive = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (blueprintActive == true)
            {
                blueprintCanvas.SetActive(false);
                inventoryCanvas.SetActive(true);
                blueprintActive = false;
            }
            else
            {
                blueprintCanvas.SetActive(true);
                inventoryCanvas.SetActive(false);
                blueprintActive = true;
            }
        }

        // Check if the player is walking to play footstep sounds
        if (isWalking && !isFootstepCoroutineRunning && audioSource != null)
        {
            StartCoroutine(PlayFootstepSounds(0.5f)); // Adjust the delay as needed
        }
    }

    IEnumerator PlayFootstepSounds(float footstepDelay)
    {
        isFootstepCoroutineRunning = true;

        while (isWalking)
        {
            if (currentFootstepSounds.Length > 0)
            {
                int randomIndex = Random.Range(0, currentFootstepSounds.Length);
                audioSource.transform.position = footstepAudioPosition.position;
                audioSource.clip = currentFootstepSounds[randomIndex];
                audioSource.Play();
                yield return new WaitForSeconds(footstepDelay);
            }
            else
            {
                yield break;
            }
        }

        isFootstepCoroutineRunning = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the player is walking
        isWalking = (horizontalInput != 0 || verticalInput != 0);

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
