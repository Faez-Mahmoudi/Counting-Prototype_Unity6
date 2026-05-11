using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1000.0f;
    [SerializeField] private float powerStrength = 3.0f;
    [SerializeField] private string ID;
    private Rigidbody playerRb;

    private AudioSource playerAudio;
    [SerializeField] AudioClip hitBallSound;
    [SerializeField] AudioClip hitPlayerSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
        playerAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.isGameActive)
        {
            float verticalInput = Input.GetAxis("Vertical" + ID);
            float horizontalInput = Input.GetAxis("Horizontal" + ID);

            playerRb.AddForce(Vector3.up * Time.deltaTime * speed * verticalInput);
            playerRb.AddForce(Vector3.forward * Time.deltaTime * speed * horizontalInput);

            transform.rotation = Quaternion.identity;
            if (transform.position.x != 0)
                Debug.Log("Somthing went wrong");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((MainManager.Instance.numberOfPlayer == 2) || (MainManager.Instance.numberOfPlayer == 1 && ID == "2"))
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                ballRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
                playerAudio.PlayOneShot(hitBallSound, 1.0f);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Rigidbody rivalRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                rivalRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
                playerAudio.PlayOneShot(hitPlayerSound, 1.0f);
            }
        }
    }
}
