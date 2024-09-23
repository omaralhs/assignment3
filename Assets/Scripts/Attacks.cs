using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator; // Assign Animator in Inspector
    [SerializeField] private string attackTrigger = "AttackTrigger"; // Animator trigger name

    private bool isAttacking = false; // Track if the player is attacking

    void Update()
    {
        // Check if the 'F' key is pressed to attack
        if (Input.GetKeyDown(KeyCode.F))
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Trigger the attack animation
        animator.SetTrigger(attackTrigger);
        isAttacking = true;
    }

    // Detect collision with the enemy (for the front arm collider)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Enemy"))
        {
            // Make the player disappear by disabling the game object or destroying it
            gameObject.SetActive(false); // This hides the player (you can use Destroy as well)
            isAttacking = false; // Reset the attack state after disappearing
        }
    }
}
