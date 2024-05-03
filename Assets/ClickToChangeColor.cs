using UnityEngine;

public class ClickToChangeColor : MonoBehaviour
{
    private Renderer rend;
    private PlayerManager playerManager;
    private GameManager _gameManager;

    public GameManager gameManager // Expose gameManager through a property
    {
        get { return _gameManager; }
        set { _gameManager = value; }
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        playerManager = FindObjectOfType<PlayerManager>(); // Find the PlayerManager in the scene
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
    }

    void OnMouseDown()
    {
        if (!GetComponent<Collider>().enabled)
        {
            return; // Exit the method if the collider is disabled
        }

        // Switch between player colors when the wall is clicked
        Material playerMaterial = playerManager.currentPlayer == Player.Player1 ? playerManager.player1Material : playerManager.player2Material;
        rend.material.color = playerMaterial.color;

        // Disable the collider to prevent further clicks
        GetComponent<Collider>().enabled = false;

        // Notify the GameManager that the wall color has changed
        gameManager.CheckBoxCompletion(gameObject);

        // Switch to the next player
        playerManager.currentPlayer = (playerManager.currentPlayer == Player.Player1) ? Player.Player2 : Player.Player1;
    }
}

