using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Komponen")]
    public Rigidbody2D playerRb;
    public SpriteRenderer mayaspriteRenderer;

    [Header("Parameter Gerakan")]
    public float movespeed = 5f;
    public float sprintMultiplier = 1.5f;

    [Header("Parameter Lompat")]
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private float horizontalInput;
    private bool isGrounded;
    private bool isJumping;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Cek jika sedang dialog, maka tidak bisa bergerak
        if (DialogueManager.Instance != null && DialogueManager.Instance.isDialogueActive)
        {
            horizontalInput = 0;
            playerAnimator.SetFloat("xVelocity", 0);
            playerAnimator.SetBool("isRunning", false);
            return;
        }

        // Ambil input horizontal
        horizontalInput = Input.GetAxis("Horizontal");

        // Cek input lompat
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isJumping = true;
        }

        // Balik sprite sesuai arah
        if (horizontalInput < 0)
        {
            mayaspriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            mayaspriteRenderer.flipX = false;
        }

        // Kirim data ke Animator
        float actualSpeed = Mathf.Abs(playerRb.velocity.x);
        if (actualSpeed < 0.05f) actualSpeed = 0f;

        playerAnimator.SetFloat("xVelocity", actualSpeed);
        playerAnimator.SetBool("isGrounded", isGrounded);

        // Kirim status sprint ke animator
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && horizontalInput != 0;
        playerAnimator.SetBool("isRunning", isSprinting);
    }

    void FixedUpdate()
    {
        // Cek apakah player menyentuh tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Atur kecepatan saat sprint
        float currentSpeed = movespeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Gerak horizontal
        playerRb.velocity = new Vector2(horizontalInput * currentSpeed, playerRb.velocity.y);

        // Jika lompat
        if (isJumping)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    // Untuk visualisasi groundCheck di editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
