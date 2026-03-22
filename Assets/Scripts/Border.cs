using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private float playerForce;
    [SerializeField] private Vector3 forceDirection;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(forceDirection * playerForce, ForceMode.Impulse);
            //playerAudio.PlayOneShot(groundSound, 1.0f);
        }
    }
}
