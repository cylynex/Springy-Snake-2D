using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (gameController.gameRunning) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

}
