using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    private void Update() {
        if (transform.position.x > 10) {
            Destroy(gameObject);
        } else if (transform.position.x < -10) {
            Destroy(gameObject);
        }
    }

}
