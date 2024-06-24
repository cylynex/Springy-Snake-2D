using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartPanel : MonoBehaviour {

    [SerializeField] PlayerController playerController;
    [SerializeField] Level currentLevel;
    PlayerData playerData;

    [Header("UI")]
    [SerializeField] TMP_Text star1Text;
    [SerializeField] TMP_Text star2Text;
    [SerializeField] TMP_Text star3Text;
    [SerializeField] TMP_Text[] starText;
    [SerializeField] GameObject powerUpPanel;

    private void Awake() {
        Time.timeScale = 0;
        playerController = FindObjectOfType<PlayerController>();
        playerData = FindObjectOfType<PlayerData>();
        currentLevel = playerData.currentLevelData;
        
    }

    private void Start() {
        SetupWelcomeScreen();
    }

    void SetupWelcomeScreen() {

        // First star just for beating the board
        int locationIndex = 0;
        starText[locationIndex].text = "Make it to the red platform";
        locationIndex++;

        if (currentLevel.timer1) {
            starText[locationIndex].text = "Complete the board in less than " + currentLevel.timer1Time + " seconds";
            locationIndex++;
        }

        if (currentLevel.timer2) {
            starText[locationIndex].text = "Complete the board in less than " + currentLevel.timer2Time + " seconds";
            locationIndex++;
        }

        if (currentLevel.maxBounces) {
            starText[locationIndex].text = "Complete the board in less than " + currentLevel.maxBounceCount + " jumps";
        }

        // Power Ups!!
        int powerUps = 0;
        if (playerData.powerUpShield1 > 0) {
            print("you have a shield you can use");
            powerUps++;
        }
    }

    public void StartGame() {
        Time.timeScale = 1;
        playerController.gameRunning = true;
        powerUpPanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
