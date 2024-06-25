using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpPanel : MonoBehaviour {
    
    PlayerData playerData;
    [SerializeField] GameObject shield1Button;
    PlayerController playerController;
    [SerializeField] ParticleSystem shield1FX;
    [SerializeField] TMP_Text powerUpText;

    private void Awake() {
        playerData = FindObjectOfType<PlayerData>();
        playerController = FindObjectOfType<PlayerController>();

        // check for available power ups and present button for what they have
        // TODO - should be a visual or something here when they select a powerup
        // Also need to see if another powerup is active and turn them off, as we only want 1 at a time to be live
        if (playerData.powerUpShield1 > 0) {
            shield1Button.SetActive(true);
            TMP_Text[] labels = shield1Button.GetComponentsInChildren<TMP_Text>();
            labels[1].text = playerData.powerUpShield1.ToString();
        }
    }

    public void ActivateShield1() {
        playerController.shield1 = true;
        Instantiate(shield1FX, playerController.gameObject.transform);
        powerUpText.text = "1 Hit Shield Active";
        playerData.powerUpShield1 -= 1;  
    }
}
