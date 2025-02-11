using UnityEngine;

public class Enemy : MonoBehaviour, HealthComponent
{
    Transform target;
    Vector3 moveDirection;
    SpriteRenderer sprite;
    Animator animator;

    private float moveSpeed = 2f;
    public float Health { get; set; } = 100f;


    public void takeDamage(float amount) {
        Health -= amount;

        //play death animatoin if dead
        if (Health <= 0) {
            animator.SetTrigger("Kill");
            return;
        }

        //play hit animation if still alive
        animator.SetTrigger("Hit");
    }

    //called by Death Animation
    public void DestoryObject() {
        Destroy(gameObject);
    }

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
            moveDirection = direction.normalized;

            //flip sprite depending on player's position
            sprite.flipX = target.position.x < -0.5;
        }
    }

    private void FixedUpdate() {
        if (target) {
            transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Weapon") {
            takeDamage(20);
            Debug.Log("Enemy has " + Health + " left");
        }
    }
}
