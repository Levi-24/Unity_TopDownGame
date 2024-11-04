using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float knockbackForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
            if (playerController != null)
            {
                // Calculate knockback direction
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

                // Debug log for direction
                Debug.Log("Knockback Direction: " + knockbackDirection);

                playerController.ApplyKnockback(knockbackDirection, knockbackForce);
                playerController.TakeDamage(damageAmount);

            }
        }
    }
}
