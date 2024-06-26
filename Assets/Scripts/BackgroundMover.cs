using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

    [SerializeField] float moveSpeed = 0.2f;
    GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (gameController.gameRunning) { 
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

}
