using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxWallAssociation[] boxToWalls;
    private Dictionary<GameObject, bool> boxColorStates = new Dictionary<GameObject, bool>();

    public Material player1Material;
    public Material player2Material;

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

    public void CheckBoxCompletion(GameObject wall, Player player)
    {
        BoxWallAssociation association = boxToWalls.FirstOrDefault(a => a.walls.Contains(wall));

        if (association != null && association.walls.All(w => IsWallRed(w)))
        {
            ChangeBoxColor(association.box, player);
        }
        else
        {
            // Additional logic for handling box color if needed
        }
    }

    private bool IsWallRed(GameObject wall)
    {
        return wall.GetComponent<Renderer>().material.color == Color.red;
    }

    private void ChangeBoxColor(GameObject box, Player player)
    {
        Renderer boxRenderer = box.GetComponent<Renderer>();
        Material playerMaterial = player == Player.Player1 ? player1Material : player2Material;

        boxRenderer.material = playerMaterial;

        // Update the color state of the box
        boxColorStates[box] = true;
    }
}
