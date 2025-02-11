using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float moveSpeed = 2f;
    Transform target;
    Vector3 moveDirection;
    SpriteRenderer sprite;
    Animator animator;

    void Awake() {
    }

    void Start() {
        target = GameObject.Find("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update() {
        if (target) {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //flip sprite depending on player's position
            sprite.flipX = target.position.x < -1;
        }
    }

    private void FixedUpdate() {
        if (target) {
            transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Weapon") {
            animator.SetTrigger("Hit");
        }
    }
}
