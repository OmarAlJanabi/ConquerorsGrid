using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum Player
    {
        Player1,
        Player2
    }

    public class PlayerManager : MonoBehaviour
    {
        public Player currentPlayer = Player.Player1;
        public Material player1Material;
        public Material player2Material;

        // Additional player-related logic can go here
    }

