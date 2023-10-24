using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvement : MonoBehaviour
{
    public float speed = 5.0f;
    public Text scoreText;
    public AudioClip coinCollectSound;

    private int count;
    private float horizontalInput;
    private float forwardInput;
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        UpdateScoreText();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on this GameObject
        audioSource.clip = coinCollectSound; // Assign the coin collect sound to the AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Get the Rigidbody component
        Rigidbody rb = GetComponent<Rigidbody>();

        // Store the current y (upward) velocity
        float originalYVelocity = rb.velocity.y;

        // Set the y (upward) velocity to zero to prevent the ball from jumping
        rb.velocity = new Vector3(movement.x * speed, originalYVelocity, movement.z * speed);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if collider tag is "coin"
        if (collider.gameObject.CompareTag("coin"))
        {
            collider.gameObject.SetActive(false);
            count++;
            UpdateScoreText();

            // Play the coin collect sound effect
            audioSource.Play();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + count;
    }
}
