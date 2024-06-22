using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    PlayerController pc;

    private void Start() {
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if (!pc.gameOver) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

}
