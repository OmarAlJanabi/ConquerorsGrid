using UnityEngine;

public class ClickToChangeColor : MonoBehaviour
{
    public Material redMaterial; // Assign the red material in the Inspector
    public GameManager gameManager; // Reference to the GameManager script

    private Renderer rend;

    void Start()
    {
        // Get the Renderer component
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        // Change the material to red when clicked
        rend.material = redMaterial;

        // Notify the GameManager that the wall color has changed
        gameManager.CheckBoxCompletion(gameObject);
    }
}