using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Define associations between boxes and walls
    public BoxWallAssociation[] boxToWalls;

    // Dictionary to store color states of boxes
    private Dictionary<GameObject, bool> boxColorStates = new Dictionary<GameObject, bool>();

    void Start()
    {
        // Initialize box color states
        foreach (var association in boxToWalls)
        {
            boxColorStates.Add(association.box, false);
        }

        // Assuming you have a script to change the color of walls
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
        // Find the association that contains the changed wall
        BoxWallAssociation association = boxToWalls.FirstOrDefault(a => a.walls.Contains(wall));

        // Check if all walls in the association have turned red
        if (association != null && association.walls.All(w => IsWallRed(w)))
        {
            // Change the color of the box associated with the completed walls
            ChangeBoxColor(association.box, true);
        }
        else
        {
            // Change the color of the box associated with the walls back to default
            ChangeBoxColor(association.box, false);
        }
    }

    private bool IsWallRed(GameObject wall)
    {
        // Check if the wall material is red
        return wall.GetComponent<Renderer>().material.color == Color.red;
    }

    private void ChangeBoxColor(GameObject box, bool isRed)
    {
        // Change the color of the box based on the isRed flag
        Renderer boxRenderer = box.GetComponent<Renderer>();
        boxRenderer.material.color = isRed ? Color.red : Color.white;

        // Update the color state of the box
        boxColorStates[box] = isRed;
    }
}

