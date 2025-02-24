using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour, DamageComponent
{
    Transform target;
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    public TotalPoints tpUI;

    public float moveSpeed = 1.5f;
    public float damage = 10;
    public float knockbackTimer = 0f;
    public Vector2 knockbackVelocity;
    public Vector2 moveDirection;

    public static List<Enemy> allEnemies = new List<Enemy>();

    private void OnEnable() { allEnemies.Add(this); }
    private void OnDisable() { allEnemies.Remove(this); }

    //item drops <
    [SerializeField] public GameObject expPrefab;

    [System.Serializable]
    public struct ItemDrop
    {
        public GameObject itemPrefab;
        [Range(0, 100)] public float dropChance; // Percentage chance
    }
    //item drops >

    public float Health { get; set; }
    public List<ItemDrop> itemDrops;

    //reset enemy states when re-spawned from object loop
    public virtual void ResetEnemy() {
        Health = 60f;
        circleCollider.enabled = true;
        sprite.enabled = true;

        Color spriteColor = sprite.color;
        spriteColor.a = 1f;
        sprite.color = spriteColor;
    }

    public virtual void takeDamage(float amount) {
        Health -= amount;
        animator.ResetTrigger("Hit");

        //play death animatoin if dead
        if (Health <= 0) {

            tpUI.setPoints(Random.Range(20,101));

            circleCollider.enabled = false; //stops restarting animation state
            animator.SetTrigger("Kill");
            DropItems(); // Call DropItems *here* when the enemy is dead
            return;
        }

        //play hit animation if still alive
        animator.SetTrigger("Hit");
    }

    //knockback when hit
    public virtual void ApplyKnockback(float force, float duration) {
        knockbackVelocity = -moveDirection * force;
        knockbackTimer = duration;
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

    protected virtual void Start() {
        Health = 60f;
        if (tpUI == null) {
        tpUI = FindFirstObjectByType<TotalPoints>(); // Finds the active TotalPoints instance
        }
    }

    void Update() {

        if (target) {
            Vector2 direction = (target.position - transform.position).normalized;

            //separate enemies smoothly to prevent clamping
            foreach (Enemy other in allEnemies) {
                if (other != this) {
                    float distance = Vector2.Distance(transform.position, other.transform.position);
                    if (distance < 0.7f) {
                        direction += (Vector2)(transform.position - other.transform.position).normalized * 0.2f;
                    }
                }
            }

            moveDirection = direction;

            //flip sprite x-axis depending on player's position
            if (Mathf.Abs(direction.x) > 0.1f) {
                sprite.flipX = direction.x < 0;
            }
        }
    }

    private void FixedUpdate() {
        if (knockbackTimer > 0) {
            rb.MovePosition(rb.position + knockbackVelocity * Time.fixedDeltaTime);
            knockbackTimer -= Time.fixedDeltaTime;
        } else if (target) {
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
        }
    }


    //buggy dmg pls fix qwq, should tick dmg per second..
    private Coroutine damageCoroutine;
    private float tickRate = 0.8f; // Adjust tick rate as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            damageCoroutine = StartCoroutine(TickDamage(playerHealth));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth) && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator TickDamage(PlayerHealth playerHealth)
    {
        while (true)
        {
            playerHealth.takeDamage(damage);
            yield return new WaitForSeconds(tickRate);
        }
    }
}
