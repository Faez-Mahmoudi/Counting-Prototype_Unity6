using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1000.0f;
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

        //transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
    }
}
