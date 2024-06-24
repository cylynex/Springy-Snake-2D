using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    [SerializeField] GameObject star0;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    public void SetStar(int star) {
        switch(star) {
            case 0: star0.SetActive(true); break;
            case 1: star1.SetActive(true); break;
            case 2: star2.SetActive(true); break;
            case 3: star3.SetActive(true); break;
        }
    }

}
