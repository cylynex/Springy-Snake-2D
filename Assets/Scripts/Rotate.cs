using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1;

    private void Update() {
        transform.Rotate(Vector3.down    * rotateSpeed * Time.deltaTime);
    }

}
