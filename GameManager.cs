using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Set in Inspector")]
    public CamFollow    camFollow;

    public Button       startGameButton;

    public GameObject   playerGO;
    public GameObject   messageGO;

    [Header("Set dynamically")]
    private static GameManager _S;
    public static GameManager S { get { return _S; } set { _S = value; } }

    void Awake() {
        S = this;
    }

    private void Start() {
        // Add listener to start game button
        startGameButton.onClick.AddListener(delegate { StartGameButton(); });
    }

    public void StartGameButton() {
        camFollow.canMove = true;

        messageGO.SetActive(false);
        startGameButton.gameObject.SetActive(false);
    }

    public void GameOver(string message) {
        camFollow.canMove = false;
        playerGO.SetActive(false);
        messageGO.SetActive(true);

        ScoreManager.S.SetMessage(message);
        ScoreManager.S.SetLives(0);
 
        // Reload this scene in 2 seconds
        Invoke("ReloadScene", 2f);
    }

    public void ReloadScene() {
        SceneManager.LoadScene("SampleScene");
    }
}