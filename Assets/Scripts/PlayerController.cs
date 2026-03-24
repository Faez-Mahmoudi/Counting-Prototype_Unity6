using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1000.0f;
    [SerializeField] private float powerStrength = 3.0f;
    private Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.up * Time.deltaTime * speed * verticalInput);
        playerRb.AddForce(Vector3.forward * Time.deltaTime * speed * horizontalInput);

        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }
}
