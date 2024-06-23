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
            print(world.levels[i]);
            GameObject currentLevel = Instantiate(levelItemPrefab, transform);
            Button thisButton = currentLevel.GetComponentInChildren<Button>();
            print("adding " + i + " world level " + world.levels[i]);
            int thisIndex = i;
            thisButton.onClick.AddListener(() => ChooseLevel(thisIndex, world.levels[thisIndex]));
        }

        // Setup the locks
        
        int levelIndex = 0;

        foreach(Transform levelSelector in transform) {
            if (levelIndex > 0) {
                if (playerData.world1Unlocks.Contains(levelIndex)) {
                    // Disable lock icon and enable button
                    levelSelector.GetChild(2).gameObject.SetActive(false);
                    print("level " + levelIndex + " is already unlocked.");
                }
                else {
                    // Leave in default, locked state, remove button
                    print("level " + levelIndex + " is not unlocked yet");
                    levelSelector.GetChild(3).gameObject.SetActive(false);
                }
            } else {
                // Disable lock icon and enable button
                print("level " + levelIndex + " is already unlocked.");
                levelSelector.GetChild(2).gameObject.SetActive(false);
            }

            levelIndex++;
            
        }
    }

    private void ChooseLevel(int levelSaveID, string levelName) {
        print("loading level " + levelName + " of id " + levelSaveID);
        playerData.currentLevelIndex = levelSaveID;
        SceneManager.LoadScene(levelName);
    }
}
