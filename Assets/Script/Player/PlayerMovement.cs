
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private BuffUIController buffUI;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private Vector3 mousePos;
    private Vector2 moveInput;
    private Animator animator; //Animator Component
    private Camera cam;

    private bool DashOffCooldown = true;

    //checks if player is on hub or not, required for the Transition Script
    public bool isOnHub = false;

    void Start() // https://discussions.unity.com/t/temporary-buff-scripts-and-timers/110542
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerSprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        if (!buffUI.IsPaused)
        {
            AimMousePoint();
        }
    }

    //check Animator for more information..
    public void AimMousePoint()
    {
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

    public void Dash(InputAction.CallbackContext context)
    {

        if (DashOffCooldown == true && context.performed)
        {
            // add a duration for the dash and also uhh cooldown ig, also the changing of rb.linearVelocity doesn't work so fix that
            DashOffCooldown = false;
            float DashDuration = 0.2f;
            int DashCooldown = 3; // longer cooldowns maybe, this is way too short and easily usable to get out of tight spots
            moveSpeed = 25f;
            Invoke("DashStop", DashDuration);
            Invoke("ResetDashCooldown", DashCooldown);
            Debug.Log("Dash");

        }
        else
        {
            Debug.Log("On cooldown");
        }
    }

    public void DashStop()
    {
        moveSpeed = 5f;

    }

    public void ResetDashCooldown()
    {
        DashOffCooldown = true;
    }

}
