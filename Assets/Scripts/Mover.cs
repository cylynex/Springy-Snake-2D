using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField] public float moveSpeed = 4f;
    [SerializeField] bool rightToLeft = false;

    private void Update() {
        if (rightToLeft) {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        } else {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

}
