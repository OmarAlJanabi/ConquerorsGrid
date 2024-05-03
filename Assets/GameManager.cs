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
        BoxWallAssociation association = boxToWalls.FirstOrDefault(a => a.walls.Contains(wall));

        if (association != null)
        {
            // Check how many walls of the box have changed color
            int changedWallCount = 0;
            foreach (GameObject boxWall in association.walls)
            {
                if (IsWallPlayerColor(boxWall))
                {
                    changedWallCount++;
                }
            }

            // If all walls have changed color, update the box color
            if (changedWallCount == association.walls.Length)
            {
                ChangeBoxColor(association.box, wall.GetComponent<Renderer>().material.color);
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
    }
}