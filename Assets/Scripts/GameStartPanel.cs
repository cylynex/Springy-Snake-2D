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
        star1Text.text = "1 Star: Make it to the red platform";
        star2Text.text = "T2 GOESHERE";
        star3Text.text - "T3 GOES HERE";
    }

    public void StartGame() {
        Time.timeScale = 1;
        playerController.gameRunning = true;
        gameObject.SetActive(false);
    }
}
