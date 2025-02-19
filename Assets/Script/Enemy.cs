using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, HealthComponent
{
    Transform target;
    Vector2 moveDirection;
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    private float moveSpeed = 1.5f;
    private float damage = 20;

    [SerializeField] public GameObject expPrefab;

    [System.Serializable]
    public struct ItemDrop
    {
        public GameObject itemPrefab;
        [Range(0, 100)] public float dropChance; // Percentage chance
    }

    public float Health { get; set; }
    public List<ItemDrop> itemDrops;

    //reset enemy states when re-spawned from object loop
    public void ResetEnemy() {
        Health = 60f;
        circleCollider.enabled = true;
        sprite.enabled = true;

        Color spriteColor = sprite.color;
        spriteColor.a = 1f;
        sprite.color = spriteColor;
    }

    public void takeDamage(float amount) {
        Health -= amount;
        animator.ResetTrigger("Hit");

        //play death animatoin if dead
        if (Health <= 0) {

            circleCollider.enabled = false; //stops restarting animation state
            animator.SetTrigger("Kill");
            DropItems(); // Call DropItems *here* when the enemy is dead
            return;
        }

        //play hit animation if still alive
        animator.SetTrigger("Hit");
    }

    //called by Death Animation Event State
    public void DestroyObject() {
        gameObject.SetActive(false);
    }

    private void DropItems()
    {
        Instantiate(expPrefab, transform.position, Quaternion.identity); //drops exp crystals

        foreach (ItemDrop itemDrop in itemDrops)
        {
            if (Random.Range(0, 100) <= itemDrop.dropChance)
            {
                Instantiate(itemDrop.itemPrefab, transform.position + new Vector3(1.5f, 0f, 0f), Quaternion.identity);
            }
        }
    }

    void Awake() {
        target = GameObject.Find("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        rb.freezeRotation = true;
    }

    void Start() {
        Health = 60f;
    }

    void Update() {
        if (target) {
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //flip sprite x-axis depending on player's position
            sprite.flipX = direction.x < 0;
        }
    }

    private void FixedUpdate() {
        if (target) {
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        PlayerHealth playerHealth = other.transform.parent?.GetComponent<PlayerHealth>();

        //if collides with player, deal damage to player
        if (playerHealth != null) {
            playerHealth.takeDamage(damage);
            return;
        }

        //if collided with sword, deal daamge to itself
        if (other.CompareTag("Weapon")) {
            takeDamage(20);
        }
    }

}
