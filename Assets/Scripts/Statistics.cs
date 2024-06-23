using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statistics : MonoBehaviour {
    
    PlayerData playerData;

    [SerializeField] TMP_Text totalJumps;
    [SerializeField] TMP_Text world1;

    private void Awake() {
        playerData = FindObjectOfType<PlayerData>();
    }

    void Start() {
        totalJumps.text = "Lifetime Jumps: "+playerData.totalJumps.ToString();
        
        string w1p = "";
        for (int i = 0; i < playerData.world1Unlocks.Count; i++) {
            w1p += playerData.world1Unlocks[i] + ", ";
        }
        world1.text = "World 1 Progress: " + w1p;
    }

}
