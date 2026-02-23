using UnityEngine;

public class Shell : MonoBehaviour
{
    [Header("Collision")]
    public string floorTag = "Floor";
    public string player1 = "Player1";
    public string player2 = "Player2";
    
    private void OnCollisionEnter(Collision collision)
    {
        // If hit player
        if (collision.gameObject.CompareTag(player1) ||
            collision.gameObject.CompareTag(player2))
        {
            TurnManager.Instance.AddScore(collision.gameObject.tag);
            TurnManager.Instance.SwitchTurn();
            Destroy(gameObject);
        }

        // If hit floor
        if (collision.gameObject.CompareTag(floorTag))
        {
            TurnManager.Instance.SwitchTurn();
            Destroy(gameObject);
        }
    }
}