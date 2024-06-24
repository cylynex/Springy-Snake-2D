using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLockManager : MonoBehaviour {

    PlayerData playerData;
    [SerializeField] World world;
    [SerializeField] GameObject levelItemPrefab;

    private void Start() {

        playerData = FindObjectOfType<PlayerData>();

        // Instantiate the level selectors
        for (int i = 0; i < world.levels.Count; i++) {
            GameObject currentLevel = Instantiate(levelItemPrefab, transform);
            Button thisButton = currentLevel.GetComponentInChildren<Button>();
            int thisIndex = i;
            thisButton.onClick.AddListener(() => ChooseLevel(thisIndex, world.levels[thisIndex]));

            // Setup the stars
            print("stars for this level : " + playerData.world1Stars[thisIndex]);
            switch (playerData.world1Stars[thisIndex]) {
                case 0: currentLevel.GetComponent<LevelSelector>().SetStar(0); break;
                case 1: currentLevel.GetComponent<LevelSelector>().SetStar(1); break;
                case 2: currentLevel.GetComponent<LevelSelector>().SetStar(2); break;
                case 3: currentLevel.GetComponent<LevelSelector>().SetStar(3); break;
                default: Debug.Log("star error"); break;
            }

        }

        // Setup the locks
        
        int levelIndex = 0;

        foreach(Transform levelSelector in transform) {
            if (levelIndex > 0) {
                if (playerData.world1Unlocks.Contains(levelIndex)) {
                    // Disable lock icon and enable button
                    levelSelector.GetChild(2).gameObject.SetActive(false);
                    //print("level " + levelIndex + " is already unlocked.");
                }
                else {
                    // Leave in default, locked state, remove button
                    //print("level " + levelIndex + " is not unlocked yet");
                    levelSelector.GetChild(3).gameObject.SetActive(false);
                }
            } else {
                // Disable lock icon and enable button
                //print("level " + levelIndex + " is already unlocked.");
                levelSelector.GetChild(2).gameObject.SetActive(false);
            }

            levelIndex++;
            
        }
    }

    private void ChooseLevel(int levelSaveID, string levelName) {
        playerData.currentLevelIndex = levelSaveID;
        playerData.currentLevelData = playerData.GetComponent<LevelData>().world1Levels[levelSaveID];
        SceneManager.LoadScene(levelName);
    }
}
