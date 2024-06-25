using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour {

    GameController gameController;
    public bool isStarted = false;
    [SerializeField] float timer = 3;
    [SerializeField] TMP_Text timerDisplay;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (isStarted) {
            timerDisplay.text = Mathf.RoundToInt(timer).ToString();
            timer -= Time.deltaTime;
        }

        if (timer <= 0) {
            isStarted = false;
            gameController.StartGame();
            gameObject.SetActive(false);
        }
    }

}
