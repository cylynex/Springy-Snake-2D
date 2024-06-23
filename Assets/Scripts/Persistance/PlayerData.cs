using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    // Temp Data
    [Header("Temp Data")]
    [SerializeField] public int currentLevelIndex = 0;

    // Save Data
    [Header("Savable Data")]
    public int totalJumps = 0;
    public List<int> world1Unlocks = new List<int>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            print("Total jumps known: " + totalJumps);
        }
    }

}
