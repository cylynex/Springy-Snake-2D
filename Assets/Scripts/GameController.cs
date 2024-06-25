using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    PlayerController playerController;
    PlayerData playerData;
    Level level;
    Timer timer;

    public bool gameRunning = false;

    [Header("UI")]
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;

    [Header("Sound")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip loseSound;
    [SerializeField] AudioClip winSound;

    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
        playerData = FindObjectOfType<PlayerData>();
        level = playerData.currentLevelData;
        timer = GetComponent<Timer>();
    }

    public void StartGame() {
        gameRunning = true;
        playerController.UnFreezePlayer();
    }

    public void Lose() {
        playerController.FreezePlayer();
        loseScreen.SetActive(true);
        gameRunning = false;
        audio.PlayOneShot(loseSound);
    }

    public void Win() {
        playerController.FreezePlayer();
        winScreen.SetActive(true);
        gameRunning = false;
        audio.PlayOneShot(winSound);
        playerData.totalJumps += playerController.jumpCounter;

        int levelToUnlock = playerData.currentLevelIndex + 1;
        if (!playerData.world1Unlocks.Contains(levelToUnlock)) {
            playerData.world1Unlocks.Add(levelToUnlock);
        }

        int wonStars = 1;

        // Win Conditionals - TODO break into separate methods
        if (level.timer1) {
            if (timer.timer < level.timer1Time) {
                wonStars++;
            }
        }

        if (level.timer2) {
            if (timer.timer < level.timer2Time) {
                wonStars++;
            }
        }

        if (level.maxBounces) {
            if (playerController.jumpCounter < level.maxBounceCount) {
                wonStars++;
            }
        }

        // Add or update stars in storage
        if (playerData.world1Stars[playerData.currentLevelIndex] < wonStars) {
            playerData.totalStarsEarned += (wonStars - playerData.world1Stars[playerData.currentLevelIndex]);
        }

        playerData.world1Stars[playerData.currentLevelIndex] = wonStars;
        playerData.GetComponent<Save>().SaveGame();
    }

}
