using System.Diagnostics;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public void UpdateScore(Color boxColor, PlayerManager playerManager)
    {
        if (boxColor == playerManager.player1Material.color)
        {
            player1Score++;
        }
        else if (boxColor == playerManager.player2Material.color)
        {
            player2Score++;
        }

        UnityEngine.Debug.Log("Player 1 Score: " + player1Score);
        UnityEngine.Debug.Log("Player 2 Score: " + player2Score);
    }
}
