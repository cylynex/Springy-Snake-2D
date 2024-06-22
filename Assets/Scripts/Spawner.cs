using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject spawnItem;
    [SerializeField] float spawnStart;
    [SerializeField] float spawnRepeat;
    PlayerController pc;

    private void Start() {
        pc = FindObjectOfType<PlayerController>();
        InvokeRepeating("Spawn", spawnStart, spawnRepeat);
    }

    void Spawn() {
        if (!pc.gameOver) { 
            Instantiate(spawnItem, transform.position, spawnItem.transform.rotation);
        }
    }

}
