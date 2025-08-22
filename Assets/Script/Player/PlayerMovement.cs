using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PauseGame pauseGame;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private Vector3 mousePos;
    private Vector2 moveInput;
    private Animator animator; //Animator Component
    private Camera cam;

    private bool DashOffCooldown = true;
    public float currMoveSpeed;

    //checks if player is on hub or not, required for the Transition Script
    public bool isOnHub = false;

    void Start() // https://discussions.unity.com/t/temporary-buff-scripts-and-timers/110542
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerSprite = GetComponent<SpriteRenderer>();

        currMoveSpeed = playerStats.MoveSpeed;
    }

    void Update()
    {
        rb.linearVelocity = moveInput * currMoveSpeed;

        if (!pauseGame.isPaused)
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

        if (DashOffCooldown == true && context.performed) // maybe teleport based on mouse position?
        {
            // add a duration for the dash and also uhh cooldown ig, also the changing of rb.linearVelocity doesn't work so fix that

            Vector2 mult = new Vector2(5.0f, 5.0f);
            Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 centeredViewportPoint = new Vector2(viewportPoint.x - 0.5f, viewportPoint.y - 0.5f);
            Vector2 mouseRaw = Input.mousePosition;
            Vector2 mouseRawNormalized = mouseRaw.normalized;
            DashOffCooldown = false;
            float DashCooldown = 0.5f; // longer cooldowns maybe, this is way too short and easily usable to get out of tight spots
            int DashDuration = 0;
            rb.position = rb.position + centeredViewportPoint * 5;
            Invoke("DashStop", DashDuration);
            Invoke("ResetDashCooldown", DashCooldown);
            Debug.Log(centeredViewportPoint + "centeredViewportPoint");
            
            
            

        }
    }

    public void DashStop()
    {
        currMoveSpeed = playerStats.MoveSpeed;
    }

    public void ResetDashCooldown()
    {
        DashOffCooldown = true;
    }
}
