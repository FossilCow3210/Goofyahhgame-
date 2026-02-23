using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public bool isPlayer1Turn = true;

    public int player1Score = 0;
    public int player2Score = 0;
    private PlayerMovement2 playerMovement2;
    private PlayerMovement  playerMovement;
    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(string hitTag)
    {
        if (hitTag == "Player1")
        {
            player2Score += 5;
            Debug.Log("Player 2 Score: " + player2Score);
        }
        else if (hitTag == "Player2")
        {
            player1Score += 5;
            Debug.Log("Player 1 Score: " + player1Score);
        }
    }

    public void SwitchTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;

        if (isPlayer1Turn)
        
            GetComponent<PlayerMovement>().enabled = true;
        else
             GetComponent<PlayerMovement2>().enabled = true; 
        GetComponent<PlayerMovement>().enabled = false;
           
    }
}



