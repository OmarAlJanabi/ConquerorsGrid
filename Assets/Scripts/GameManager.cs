using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BoxWallAssociation[] boxToWalls;
    private Dictionary<GameObject, bool> boxColorStates = new Dictionary<GameObject, bool>();
    private GameObject lastClickedWall;
    public static GameManager instance;
    public Material player1Material;
    public Material player2Material;
    public PlayerManager playerManager;
    public ScoreManager scoreManager; // Reference to ScoreManager script
    private bool allowNextTurn = true; // Flag to allow the next turn
    public GameObject winScreen;
    public TextMeshProUGUI outcomeText;
   

    void Update()
    {
        // Check if the turn should be allowed
        if (allowNextTurn)
        {
            // Check for player input to take the next turn
            if (Input.GetMouseButtonDown(0))
            {
                // Switch to the next player
                playerManager.currentPlayer = (playerManager.currentPlayer == Player.Player1) ? Player.Player2 : Player.Player1;
                allowNextTurn = false; // Disallow the next turn until a box is scored
            }
        }
        if (IsGameOver())
        {
            DetermineOutcome();
            ActivateWinScreen();
        }
    }

    void Start()
    {
        foreach (var association in boxToWalls)
        {
            boxColorStates.Add(association.box, false);
        }

        foreach (var association in boxToWalls)
        {
            foreach (GameObject wall in association.walls)
            {
                wall.GetComponent<ClickToChangeColor>().gameManager = this;
            }
        }
    }

    bool IsGameOver()
    {
        int totalScore = scoreManager.player1Score + scoreManager.player2Score;
        return totalScore >= 32;
    }

    public void CheckBoxCompletion(GameObject wall)
    {
        foreach (var association in boxToWalls)
        {
            if (association.walls.Contains(wall))
            {
                // Check if all walls for this box have changed color
                bool allWallsColored = association.walls.All(w => IsWallPlayerColor(w));

                // If all walls for this box have changed color, update the box color
                if (allWallsColored)
                {
                    ChangeBoxColor(association.box, wall.GetComponent<Renderer>().material.color);

                    // Update the score and allow the next turn
                    scoreManager.UpdateScore(wall.GetComponent<Renderer>().material.color, playerManager);
                    allowNextTurn = true;
                }
            }
        }
    }


    private bool IsWallPlayerColor(GameObject wall)
    {
        Color wallColor = wall.GetComponent<Renderer>().material.color;
        return wallColor == playerManager.player1Material.color || wallColor == playerManager.player2Material.color;
    }

    private void ChangeBoxColor(GameObject box, Color color)
    {
        Renderer boxRenderer = box.GetComponent<Renderer>();
        boxRenderer.material.color = color;

        // Update the color state of the box
        boxColorStates[box] = true;
        scoreManager.UpdateScore(color, playerManager);
    }

    void DetermineOutcome()
    {
        string outcome = "";
        if (scoreManager.player1Score > scoreManager.player2Score)
        {
            outcome = "Player 1 Wins!";
        }
        else if (scoreManager.player2Score > scoreManager.player1Score)
        {
            outcome = "Player 2 Wins!";
        }
        else
        {
            outcome = "Draw!";
        }
        outcomeText.text = outcome;
    }
    void ActivateWinScreen()
    {
        winScreen.SetActive(true);
    }
}