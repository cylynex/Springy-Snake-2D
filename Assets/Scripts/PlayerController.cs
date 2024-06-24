using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    PlayerData playerData;
    GameObject gameConditionals;
    Timer timer;
    Level level;

    [SerializeField] float bounceAmount;
    [SerializeField] float moveSpeed;
    Camera cam;
    
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;

    [Header("Sound")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip bounceSound;
    [SerializeField] AudioClip loseSound;
    [SerializeField] AudioClip winSound;

    [SerializeField] int health = 3;
    [SerializeField] Slider healthBar;
    [SerializeField] ParticleSystem dustPuff;

    [Header("Powerups")]
    public bool shield1 = false;


    // Stars
    int wonStars = 0;

    private float bumperLeft = -2.5f;
    private float bumperRight = 2.5f;

    public bool gameRunning = false;
    public bool gameOver = false;

    [SerializeField] int jumpCounter;
    [SerializeField] TMP_Text jumpDisplay;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        audio = GetComponent<AudioSource>();
        playerData = FindObjectOfType<PlayerData>();
        timer = GetComponent<Timer>();
        level = playerData.currentLevelData;
    }

    private void Update() {
        if (gameRunning) {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);

            if (transform.position.x < bumperLeft) {
                transform.position = new Vector2(bumperLeft, transform.position.y);
            }

            if (transform.position.x > bumperRight) {
                transform.position = new Vector2(bumperRight, transform.position.y);
            }

            CheckDie();
        }
    }

    void CheckDie() {
        if (gameRunning) {
            if (transform.position.y < (cam.transform.position.y - 5.5)) {
                Lose();
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            TakeDamage();
        }

        else if (collision.gameObject.CompareTag("Obstacle")) {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if (layerName == "Bounce") {
            if (rb.velocity.y < 0) { // Make sure its moving down first
                if (gameRunning) Bounce();
            }
        }

        else if (layerName == "Win") {
            Win();
        }

        else if (layerName == "Enemy") {
            if (shield1) {
                shield1 = false;
                ParticleSystem shieldFX = GetComponentInChildren<ParticleSystem>();
                Destroy(shieldFX.gameObject);
            }
            else {
                TakeDamage();
            }
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
        jumpDisplay.text = "Jumps: "+jumpCounter.ToString();
    }

    void TakeDamage() {
        health--;
        healthBar.value = health;
        if (health <= 0) {
            Lose();
        }
    }

    void Lose() {
        loseScreen.SetActive(true);
        gameRunning = false;
        audio.PlayOneShot(loseSound);
    }

    void Win() {
        winScreen.SetActive(true);
        gameRunning = false;
        audio.PlayOneShot(winSound);
        playerData.totalJumps += jumpCounter;
        
        int levelToUnlock = playerData.currentLevelIndex + 1;
        if (!playerData.world1Unlocks.Contains(levelToUnlock)) {
            playerData.world1Unlocks.Add(levelToUnlock);
        }

        int wonStars = 1;

        // Win Conditionals - TODO break into separate methods
        if (level.timer1) {
            if (timer.timer < level.timer1Time) {
                print("earned another star for beating timer1");
                wonStars++;
            }
        }

        if (level.timer2) {
            if (timer.timer < level.timer2Time) {
                print("earned another star for beating timer2");
                wonStars++;
            }
        }

        if (level.maxBounces) {
            if (bounceAmount < level.maxBounceCount) {
                wonStars++;
            }
        }

        // Add or update stars in storage
        if (playerData.world1Stars[playerData.currentLevelIndex] < wonStars) {
            print("earned some new stars tally em up - "+wonStars);
            int newStars = wonStars - playerData.world1Stars[playerData.currentLevelIndex];
            playerData.totalStarsEarned += newStars;
        }

        playerData.world1Stars[playerData.currentLevelIndex] = wonStars;

        playerData.GetComponent<Save>().SaveGame();
    }

}
