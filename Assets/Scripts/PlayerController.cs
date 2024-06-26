using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // References
    [Header("References")]
    Rigidbody2D rb;
    PlayerData playerData;
    Camera cam;
    GameController gameController;

    // Movement
    private float bumperLeft = -2.5f;
    private float bumperRight = 2.5f;

    [Header("Configurable")]
    [SerializeField] float bounceAmount;
    [SerializeField] float moveSpeed;
    
    [Header("Sound")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip bounceSound;
    [SerializeField] AudioClip hitSound;

    [Header("Health")]
    [SerializeField] int health = 3;
    [SerializeField] Slider healthBar;

    [Header("FX")]
    [SerializeField] ParticleSystem dustPuff;
    [SerializeField] ParticleSystem enemyHitParticles;

    [Header("Powerups")]
    public bool shield1 = false;

    [SerializeField] public int jumpCounter;
    [SerializeField] TMP_Text jumpDisplay;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        FreezePlayer();
        cam = Camera.main;
        audio = GetComponent<AudioSource>();
        playerData = FindObjectOfType<PlayerData>();
    }

    private void Update() {
        if (gameController.gameRunning) {
            MovePlayer();
            CheckDie();
        }
    }

    private void MovePlayer() {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);

        if (transform.position.x < bumperLeft) {
            transform.position = new Vector2(bumperLeft, transform.position.y);
        }

        if (transform.position.x > bumperRight) {
            transform.position = new Vector2(bumperRight, transform.position.y);
        }
    }

    void CheckDie() {
        if (gameController.gameRunning) {
            if (transform.position.y < (cam.transform.position.y - 5.5)) {
                gameController.Lose();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if (layerName == "Bounce") {
            if (rb.velocity.y < 0) { // Make sure its moving down first
                if (gameController.gameRunning) Bounce();
            }
        }

        else if (layerName == "Win") {
            if (rb.velocity.y < 0) {
                gameController.Win();
            }
        }

        else if (layerName == "Enemy") {
            if (shield1) {
                shield1 = false;
                ParticleSystem shieldFX = GetComponentInChildren<ParticleSystem>(); // getting ahold of the wrong particle system, need to reference this better
                Destroy(shieldFX.gameObject);
            } else {
                TakeDamage();
            }

            Instantiate(enemyHitParticles, transform);
            audio.PlayOneShot(hitSound);
        }
    }

    void Bounce() {
        audio.PlayOneShot(bounceSound);
        //dustPuff.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity
        rb.AddForce(Vector2.up * bounceAmount, ForceMode2D.Impulse);
        UpdateJumpCounter();
    }

    private void UpdateJumpCounter() {
        jumpCounter++;
        jumpDisplay.text = jumpCounter.ToString();
    }

    void TakeDamage() {
        health--;
        healthBar.value = health;
        if (health <= 0) {
            gameController.Lose();
        }
    }

    public void FreezePlayer() {
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
    }

    public void UnFreezePlayer() {
        rb.gravityScale = 1;
    }
}
