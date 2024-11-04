using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    [Header("Character Attributes")]
    [SerializeField] public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private int level = 5;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float dashSpeed = 1000f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashCooldown = 1f;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rb;

    private Vector2 moveDirection;
    private bool isDashing;
    private float dashEndTime;
    private float nextDashTime;

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextDashTime)
        {
            StartDash();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * (isDashing ? dashSpeed : moveSpeed) * Time.fixedDeltaTime;

        if (isDashing && Time.time >= dashEndTime)
        {
            isDashing = false;
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + dashCooldown;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
