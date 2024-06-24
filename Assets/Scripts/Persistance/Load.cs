using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public class Load : MonoBehaviour {

    [SerializeField] PlayerData playerData;

    private void Awake() {
        playerData = GetComponent<PlayerData>();
        LoadGame();
    }
        
    private void LoadGame() {
        string pathToLoad = Application.persistentDataPath + "/save.dat";
        if (!File.Exists(pathToLoad)) {
            Debug.Log("No saved profile found! Create new game.  Do stuff that hasnt been done yet here.");
            for (int i = 0; i < 5; i++) {
                playerData.world1Stars.Add(0);
            }
            GetComponent<Save>().SaveGame();
        }

        else {
            // Found save file - load
            Debug.Log("loading game: " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(pathToLoad, FileMode.Open);
            SavedProfile loadedProfile = bf.Deserialize(fs) as SavedProfile;
            fs.Close();

            // Load Data
            playerData.totalJumps = loadedProfile.totalJumps;  // Overall total jumps on file

            // World 1 unlocks
            playerData.world1Unlocks = loadedProfile.world1Unlocks;

            // World 1 Stars
            playerData.world1Stars = loadedProfile.world1Stars;

            playerData.totalStarsEarned = loadedProfile.totalStarsEarned;
        }
    }

    // Setup the load listener
    public void LoadedGameStart() {
        /*
        if (Player.isDocked) {
            SceneManager.LoadScene("Starport");
        } else {
            SceneManager.LoadScene("Game");
        }
        */
    }

}
