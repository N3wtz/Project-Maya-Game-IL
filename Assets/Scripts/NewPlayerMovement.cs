using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Komponen")]
    public Rigidbody2D playerRb;
    public SpriteRenderer mayaspriteRenderer;
    public AudioSource audioSource;

    [Header("SFX")]
    public AudioClip footstepClip;
    public AudioClip jumpClip;
    public AudioClip landClip;

    [Header("Parameter Gerakan")]
    public float movespeed = 5f;
    public float sprintMultiplier = 1.5f;

    [Header("Parameter Lompat")]
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.05f;
    public LayerMask groundLayer;

    private float horizontalInput;
    private bool isGrounded;
    private bool isJumping;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        // Auto-assign AudioSource jika belum di-assign dari Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (DialogueManager.Instance != null && DialogueManager.Instance.isDialogueActive)
        {
            horizontalInput = 0;
            playerAnimator.SetFloat("xVelocity", 0);
            playerAnimator.SetBool("isRunning", false);
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isJumping = true;
        }

        if (horizontalInput < 0)
        {
            mayaspriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            mayaspriteRenderer.flipX = false;
        }

        float actualSpeed = Mathf.Abs(playerRb.velocity.x);
        if (actualSpeed < 0.05f) actualSpeed = 0f;

        playerAnimator.SetFloat("xVelocity", actualSpeed);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && horizontalInput != 0;
        playerAnimator.SetBool("isRunning", isSprinting);

        playerAnimator.SetFloat("yVelocity", playerRb.velocity.y);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? movespeed * sprintMultiplier : movespeed;
        playerRb.velocity = new Vector2(horizontalInput * currentSpeed, playerRb.velocity.y);

        if (isJumping)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isGrounded = false;
            isJumping = false;

            PlaySound("jump");
        }

        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    public void PlaySound(string clipName)
    {
        Debug.Log("Memainkan suara: " + clipName);

        if (audioSource == null) return;

        switch (clipName)
        {
            case "footstep":
                if (footstepClip != null)
                {
                    float pitch = Random.Range(0.5f, 1.25f); // variasi pitch lebih besar
                    audioSource.pitch = pitch;
                    Debug.Log("Footstep pitch: " + pitch);  // ? Ini debug log-nya
                    audioSource.PlayOneShot(footstepClip);
                    audioSource.pitch = 1f; // reset pitch agar tidak mempengaruhi suara lain
                }
                break;
            case "jump":
                if (jumpClip != null) audioSource.PlayOneShot(jumpClip);
                break;
            case "land":
                if (landClip != null) audioSource.PlayOneShot(landClip);
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
