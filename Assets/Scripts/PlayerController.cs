using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

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

    private float bumperLeft = -2.5f;
    private float bumperRight = 2.5f;

    public bool gameOver = false;

    [SerializeField] int jumpCounter;
    [SerializeField] TMP_Text jumpDisplay;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        audio = GetComponent<AudioSource>();
    }

    private void Update() {
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

    void CheckDie() {
        if (!gameOver) {
            if (transform.position.y < (cam.transform.position.y - 6)) {
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
                if (!gameOver) Bounce();
            }
        }

        else if (layerName == "Win") {
            Win();
        }

        else if (layerName == "Enemy") {
            Destroy(other.gameObject);
            TakeDamage();
        }
        /*
        else if (other.gameObject.CompareTag("Trap")) {
            if (rb.velocity.y <= 0) {
                TakeDamage();
            }
        }

        else if (other.gameObject.CompareTag("Spider")) {
            if (rb.velocity.y <= 0) {
                TakeDamage();
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
        */
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
        gameOver = true;
        audio.PlayOneShot(loseSound);
    }

    void Win() {
        winScreen.SetActive(true);
        gameOver = true;
        audio.PlayOneShot(winSound);
    }

}
