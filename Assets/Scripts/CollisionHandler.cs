using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    //coins
    private const int CoinValue = 1;
    private const int ShooperValue = 1;



    [Header("Collision Settings")]
    public float damagePerCollision = 25f;



    private int collisionCount = 0;
    private HealthManager healthManager;



    private void Awake()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionCount++;

            if (healthManager != null)
            {
                healthManager.TakeDamage(damagePerCollision);
            }

            Debug.Log($"Collision Count: {collisionCount}");

            // Check if health bar should reach zero
            if (collisionCount >= 4)
            {
                Debug.Log("Health bar has reached zero.");
                healthManager.TakeDamage(healthManager.maxHealth); // Ensure health is zero

            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinManager.Instance?.AddCoins(CoinValue);
        }
        else if (other.gameObject.CompareTag("Shooper"))
        {
            Destroy(other.gameObject);
            ShooperManager.Instance?.AddShoopers(ShooperValue);
        }
        else if (other.CompareTag("Health"))
        {
            if (healthManager != null)
            {
                float healAmount = healthManager.maxHealth * 0.50f;
                float newHealth = healthManager.currentHealth + healAmount;
                healthManager.currentHealth = Mathf.Clamp(newHealth, 0, healthManager.maxHealth);

                // Update the health bar
                healthManager.Heal(0);
            }

            Destroy(other.gameObject);
        }
    }
}
