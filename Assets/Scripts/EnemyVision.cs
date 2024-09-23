using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform player; // Reference to the player
    public GameObject visionCone; // The triangle sprite (vision cone)

    private bool isPlayerDetected = false;

    private void Start()
    {
        // Ensure the vision cone's collider is a trigger
        PolygonCollider2D visionCollider = visionCone.GetComponent<PolygonCollider2D>();
        if (visionCollider != null)
        {
            visionCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the vision cone
        if (other.CompareTag("Player"))
        {
            Debug.Log("print");
            isPlayerDetected = true;
            OnPlayerDetected();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exited the vision cone
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
        }
    }

    private void OnPlayerDetected()
    {
        if (isPlayerDetected)
        {
            Debug.Log("Player detected!!! You Lost!!");
            Time.timeScale = 0; // Stop the game or handle game over logic
        }
    }
}
