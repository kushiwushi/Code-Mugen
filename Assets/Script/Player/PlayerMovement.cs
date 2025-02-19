using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private Vector3 mousePos;
    private Vector2 moveInput;
    private Animator animator; //Animator Component
    private Camera cam;

    //checks if player is on hub or not, required for the Transition Script
    public bool isOnHub = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        AimMousePoint();
    }

    //check Animator for more information..
    public void AimMousePoint() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        //flip horizontantly based on the mouse position
        playerSprite.flipX = rotation.x < -0.5f;
    }

    //Play animation for the player whichever state it is, using Input System Package
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        //when keys are released
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
        }
        moveInput = context.ReadValue<Vector2>();
    }
}
