using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager gameManager = (GameManager)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Box-Wall Associations", EditorStyles.boldLabel);

        for (int i = 0; i < gameManager.boxToWalls.Length; i++)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            GameObject box = EditorGUILayout.ObjectField("Box", gameManager.boxToWalls[i].box, typeof(GameObject), true) as GameObject;

            EditorGUILayout.LabelField("Walls", EditorStyles.boldLabel);

            for (int j = 0; j < gameManager.boxToWalls[i].walls.Length; j++)
            {
                gameManager.boxToWalls[i].walls[j] = EditorGUILayout.ObjectField("Wall " + (j + 1), gameManager.boxToWalls[i].walls[j], typeof(GameObject), true) as GameObject;
            }

            EditorGUILayout.EndVertical();
        }

        if (GUILayout.Button("Add Box-Wall Association"))
        {
            ArrayUtility.Add(ref gameManager.boxToWalls, new BoxWallAssociation(null, new GameObject[4]));
        }
    }
}