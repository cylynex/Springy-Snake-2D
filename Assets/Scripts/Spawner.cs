using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject spawnItem;
    [SerializeField] float spawnStart;
    [SerializeField] float spawnRepeat;
    [SerializeField] float moveSpeed = 4f;
    PlayerController pc;
    GameController gameController;

    private void Start() {
        pc = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
        InvokeRepeating("Spawn", spawnStart, spawnRepeat);
    }

    void Spawn() {
        if (gameController.gameRunning) { 
            GameObject thisBird = Instantiate(spawnItem, transform.position, spawnItem.transform.rotation);
            thisBird.GetComponent<Mover>().moveSpeed = moveSpeed;
        }
    }

}
