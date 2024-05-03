using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxWallAssociation
{
    public GameObject box;
    public GameObject[] walls;

    public BoxWallAssociation(GameObject box, GameObject[] walls)
    {
        this.box = box;
        this.walls = walls;
    }
}