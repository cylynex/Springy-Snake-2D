using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    // Temp Data
    [Header("Temp Data")]
    [SerializeField] public int currentLevelIndex = 0;
    [SerializeField] public Level currentLevelData;

    // Save Data
    [Header("Progression Data")]
    public int totalJumps = 0;
    public List<int> world1Unlocks = new List<int>();
    public List<int> world1Stars = new List<int>();

    [Header("Long Term Data")]
    public int totalStarsEarned = 0;

    [Header("Powerups")]
    public int powerUpShield1 = 0;

    private void Update() {
        
    }

}
