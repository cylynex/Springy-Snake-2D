using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class SavedProfile {

    // Progression Data
    public int totalJumps;
    public List<int> world1Unlocks = new List<int>();
    public List<int> world1Stars = new List<int>();

    // Long Term Data
    public int totalStarsEarned;

    // Power Ups
    public int powerUpShield1;

}

public class Save : MonoBehaviour {

    public SavedProfile profile;
    public PlayerData playerData;

    private void Awake() {
        playerData = GetComponent<PlayerData>();
    }

    public void SaveGame() {

        if (profile == null) {
            Debug.Log("creating new save profile");
            profile = new SavedProfile();
        }

        Debug.Log("saving game");

        profile.totalJumps = playerData.totalJumps;
        profile.world1Unlocks = playerData.world1Unlocks;
        profile.world1Stars = playerData.world1Stars;

        // Long Term Data
        profile.totalStarsEarned = playerData.totalStarsEarned;

        // Power Ups
        profile.powerUpShield1 = playerData.powerUpShield1;

        // The actual write
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.dat";
        Debug.Log("path is: " + Application.persistentDataPath);

        if (File.Exists(path))
            File.Delete(path);

        FileStream fs = File.Open(path, FileMode.OpenOrCreate);
        bf.Serialize(fs, profile);

        fs.Close();
    }




    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveGame();
            Debug.Log("Game saved!");
        }
    }
}
