using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    private static DontDestroy _instance;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (_instance != this) {
            Destroy(gameObject); 
        }
    }

}
