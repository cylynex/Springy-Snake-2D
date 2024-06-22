using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHole : MonoBehaviour {

    Animator anim;
    bool squished = false;

    private void Start() {
        InvokeRepeating("PopSpider", 1, 10);
    }

    void PopSpider() {
        anim.SetTrigger("SpiderPop");
    }

}
