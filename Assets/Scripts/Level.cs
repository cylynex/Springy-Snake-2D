using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level", order = 1)]
public class Level : ScriptableObject {

    [Header("Timer Options")]
    public bool timed2star;
    public float timer2star;

    public bool timed3star;
    public float timer3star;

}
