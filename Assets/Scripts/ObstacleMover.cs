using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField] float speed = 1f;

    private void Update() {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.localPosition = Vector3.Lerp(pointA, pointB, time);
    }


}
