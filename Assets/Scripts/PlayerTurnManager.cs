using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    // Enum to represent player colors
    public enum PlayerColor
    {
        Red,
        Blue
    }

    // Current player color
    private PlayerColor currentPlayerColor = PlayerColor.Red;

    // Method to switch player turn
    public void SwitchPlayerTurn()
    {
        // Switch player turn
        currentPlayerColor = (currentPlayerColor == PlayerColor.Red) ? PlayerColor.Blue : PlayerColor.Red;
    }

    // Method to get the current player color
    public PlayerColor GetCurrentPlayerColor()
    {
        return currentPlayerColor;
    }
}
