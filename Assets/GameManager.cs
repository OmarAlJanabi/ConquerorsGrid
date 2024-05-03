using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
}