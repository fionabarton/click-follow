using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles what happens after the player game object collides with certain other game objects.
public class PlayerCollisions : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            if(ScoreManager.S.lives > 1) {
                // Reset player position
                transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

                // Decrement score
                ScoreManager.S.SetLives(ScoreManager.S.lives - 1);
            } else {
                // Game over
                GameManager.S.GameOver("Game Over!");
            }
        } else if (coll.gameObject.tag == "Collectable") {
            // Deactivate collectable game object
            coll.gameObject.transform.parent.gameObject.SetActive(false);

            // Increment score
            ScoreManager.S.SetScore(ScoreManager.S.score + 1);
        } else if (coll.gameObject.tag == "Goal") {
            // Successfully completed level
            GameManager.S.GameOver("Level Completed!");
        }
    }
}