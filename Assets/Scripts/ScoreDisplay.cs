using UnityEngine;
using TMPro;
using System.Diagnostics;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI currentPlayerText;
    public ScoreManager scoreManager; // Reference to ScoreManager script
    public PlayerManager playerManager; // Reference to PlayerManager scrip

    void Start()
    {
        

        // Update the initial score display
        UpdateScoreDisplay();
    }

    void Update()
    {
        // Update the score display continuously (optional)
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        // Update player 1 score text
        player1ScoreText.text =  scoreManager.player1Score.ToString();

        // Update player 2 score text
        player2ScoreText.text =  scoreManager.player2Score.ToString();

        currentPlayerText.text = (playerManager.currentPlayer == Player.Player1 ? "Player 1" : "Player 2");
    }
}