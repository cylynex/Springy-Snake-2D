using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

    [SerializeField] float moveSpeed = 0.2f;

    private void Update() {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

}
