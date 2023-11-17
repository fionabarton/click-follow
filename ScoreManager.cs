using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//
public class ScoreManager : MonoBehaviour {
    [Header("Set in Inspector")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI messageText;

    [Header("Set dynamically")]
    public int  score = 0;
    public int  lives = 3;

    private static ScoreManager _S;
    public static ScoreManager S { get { return _S; } set { _S = value; } }

    void Awake() {
        S = this;
    }

    public void SetScore(int newValue) {
        score = newValue;
        scoreText.text = "Score: " + score;
    }

    public void SetLives(int newValue) {
        lives = newValue;
        livesText.text = "Lives: " + lives;
    }

    public void SetMessage(string newValue = "") {
        messageText.text = newValue;
        Invoke("ResetMessage", 2);
    }

    public void ResetMessage() {
        messageText.text = "";
    }
}