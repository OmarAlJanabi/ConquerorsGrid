using UnityEngine;

public class ClickToChangeColor : MonoBehaviour
{
    public PlayerManager playerManager;
    private Renderer rend;
    public GameManager gameManager; // Reference to GameManager script


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        Material playerMaterial = playerManager.currentPlayer == Player.Player1 ? playerManager.player1Material : playerManager.player2Material;

        rend.material = playerMaterial;

        gameManager.CheckBoxCompletion(gameObject, playerManager.currentPlayer);

        // Switch to the next player
        playerManager.currentPlayer = (playerManager.currentPlayer == Player.Player1) ? Player.Player2 : Player.Player1;
    }
}