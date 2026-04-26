using UnityEngine;

public class SinglePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float powerStrength = 3.0f;
    private Rigidbody playerRb;
    private GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.isGameActive)
        {
            Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
            playerRb.AddForce(lookDirection * speed * Time.timeScale);

            transform.rotation = Quaternion.identity;
            if (transform.position.x != 0)
                Debug.Log("Somthing went wrong");
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            ballRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rivalRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            rivalRb.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }
}
