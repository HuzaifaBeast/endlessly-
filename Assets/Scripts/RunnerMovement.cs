using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneDistance = 2f;
    public float jumpForce = 7f;
    public float speedIncreaseAmount = 2f;  // how much to increase each time
    public float speedIncreaseInterval = 100f; // every 100 meters

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [Header("Slide Settings")]
    public float slideDuration = 1.0f;
    public float slideHeight = 1.0f;

    [Header("Audio Clips")]
    public AudioClip bgMusic;
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioClip moveSound;

    private int currentLane = 1;
    private Animator animator;
    private Rigidbody rb;
    private CapsuleCollider capsule;
    private bool isGrounded = true;
    private bool isDead = false;
    private bool isSliding = false;

    private float defaultColliderHeight;
    private Vector3 defaultColliderCenter;

    private AudioSource audioSource;

    [HideInInspector] public bool hasStarted = false;

    private float nextSpeedIncreaseZ = 100f;  // first threshold

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        defaultColliderHeight = capsule.height;
        defaultColliderCenter = capsule.center;

        animator.SetBool("isRunning", false);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDead) return;

        if (!hasStarted)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        animator.SetBool("isRunning", true);

        // Lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            PlaySound(moveSound);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            PlaySound(moveSound);
        }

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isSliding)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("isJumping");
            PlaySound(jumpSound);
        }

        // Slide
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && !isSliding)
        {
            StartCoroutine(Slide());
            PlaySound(slideSound);
        }

        // 🔥 Speed Increase Check
        if (transform.position.z >= nextSpeedIncreaseZ)
        {
            forwardSpeed += speedIncreaseAmount;
            nextSpeedIncreaseZ += speedIncreaseInterval;
            Debug.Log("Speed Increased! New Speed: " + forwardSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (isDead || !hasStarted) return;

        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
        Vector3 targetPos = new Vector3((currentLane - 1) * laneDistance, rb.position.y, rb.position.z) + forwardMove;

        rb.MovePosition(Vector3.Lerp(rb.position, targetPos, 15f * Time.fixedDeltaTime));
    }

    private System.Collections.IEnumerator Slide()
    {
        isSliding = true;
        animator.SetTrigger("isSliding");

        capsule.height = slideHeight;
        capsule.center = new Vector3(capsule.center.x, slideHeight / 2f, capsule.center.z);

        yield return new WaitForSeconds(slideDuration);

        capsule.height = defaultColliderHeight;
        capsule.center = defaultColliderCenter;

        isSliding = false;
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("isDead");
        rb.velocity = Vector3.zero;

        // ✅ Call UIManager to show Restart Panel
        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
            ui.OnPlayerDied();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}
