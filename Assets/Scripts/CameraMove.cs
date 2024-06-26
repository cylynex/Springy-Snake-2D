using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    GameController gameController;
    [SerializeField] bool isAntiGravity = false;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (gameController.gameRunning) {
            if (!isAntiGravity) {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            } else {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
        }
    }

}
