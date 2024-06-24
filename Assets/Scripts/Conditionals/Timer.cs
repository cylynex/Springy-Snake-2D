using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public float timer;
    PlayerController playerController;
    [SerializeField] TMP_Text timerDisplay;
    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if (playerController.gameRunning) {
            timer += Time.deltaTime;
            timerDisplay.text = "Timer: "+Mathf.RoundToInt(timer).ToString();
        }
    }

}
