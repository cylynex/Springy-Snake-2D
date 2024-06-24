using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPanel : MonoBehaviour {
    
    PlayerData playerData;
    [SerializeField] GameObject shield1Button;
    PlayerController playerController;
    [SerializeField] ParticleSystem shield1FX;

    private void Awake() {
        playerData = FindObjectOfType<PlayerData>();
        playerController = FindObjectOfType<PlayerController>();

        // check for available power ups and present button for what they have
        if (playerData.powerUpShield1 > 0) {
            shield1Button.SetActive(true);
        }
    }

    public void ActivateShield1() {
        playerController.shield1 = true;
        Instantiate(shield1FX, playerController.gameObject.transform);
        // TODO - This is commented out just for testing.  Using the shield should consume it
        //playerData.powerUpShield1 -= 1;  
    }
}
