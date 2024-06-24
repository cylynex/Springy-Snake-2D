using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource audio;

    private void Start() {
        audio = FindObjectOfType<AudioSource>();
        volumeSlider.value = audio.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    void OnVolumeChange(float value) {
        audio.volume = value;
    }


}
