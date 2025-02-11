using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private Vector2 moveInput;
    private Animator animator; //Animator Component
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        AimMousePoint();
    }

    public void AimMousePoint() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        animator.SetFloat("MouseX", rotation.x);
        animator.SetFloat("MouseY", rotation.y);
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
