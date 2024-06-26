using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public float timer;
    PlayerController playerController;
    GameController gameController;

    [SerializeField] TMP_Text timerDisplay;
    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (gameController.gameRunning) {
            timer += Time.deltaTime;
            timerDisplay.text = Mathf.RoundToInt(timer).ToString();
        }
    }

}
