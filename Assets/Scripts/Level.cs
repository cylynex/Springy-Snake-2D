using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level", order = 1)]
public class Level : ScriptableObject {

    [Header("Timer Options")]
    public bool timer1;
    public float timer1Time;

    public bool timer2;
    public float timer2Time;

    [Header("Bounce Options")]
    public bool maxBounces;
    public int maxBounceCount;

    [Header("Sound")]
    public AudioClip backgroundMusic;

}
