using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    // Counter to track points for each player
    private int redPoints = 0;
    private int bluePoints = 0;

    // TMP_Text components for displaying points
    public TMPro.TextMeshProUGUI redPointsText;
    public TMPro.TextMeshProUGUI bluePointsText;

    // Method to add points for a specific player
    public void AddPoints(int amount, PlayerTurnManager.PlayerColor playerColor)
    {
        if (playerColor == PlayerTurnManager.PlayerColor.Red)
        {
            redPoints += amount;
            UpdatePointsText(redPointsText, redPoints);
        }
        else if (playerColor == PlayerTurnManager.PlayerColor.Blue)
        {
            bluePoints += amount;
            UpdatePointsText(bluePointsText, bluePoints);
        }
    }

    // Method to update points text
    private void UpdatePointsText(TMPro.TextMeshProUGUI pointsText, int points)
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
    }
}