using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject spawnItem;
    [SerializeField] float spawnStart;
    [SerializeField] float spawnRepeat;
    PlayerController pc;
    GameController gameController;

    private void Start() {
        pc = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
        InvokeRepeating("Spawn", spawnStart, spawnRepeat);
    }

    void Spawn() {
        if (gameController.gameRunning) { 
            Instantiate(spawnItem, transform.position, spawnItem.transform.rotation);
        }
    }

}
