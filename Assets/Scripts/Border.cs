using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Border : MonoBehaviour
{
    [SerializeField] private float playerForce;
    [SerializeField] private float ballForce;
    [SerializeField] private Vector3 forceDirection;

    private AudioSource borderAudio;
    [SerializeField] AudioClip hitSound;

    void Start()
    {
        borderAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        borderAudio.PlayOneShot(hitSound, 1.0f);
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(forceDirection * playerForce, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            ballRb.AddForce(forceDirection * ballForce, ForceMode.Impulse);
        }
    }
}
