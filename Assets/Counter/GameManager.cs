using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    private float spawnCooldown = 1.0f;
    private float nextSpawnTime = 0;
    private bool movingForward = true;
    public float speed = 10f;
    public float limit = 10f;

    // Update is called once per frame
    void Update()
    {
        // Instantiate a sphere when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime && gameObject.CompareTag("Player"))
        {
            Instantiate(spherePrefab, transform.position + new Vector3(0, -1, 0), transform.rotation);
            nextSpawnTime = Time.time + spawnCooldown;
        }

        // Move the cube left and right
        if (movingForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (transform.position.z >= limit)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);

            if (transform.position.z <= -limit)
            {
                movingForward = true;
            }
        }  
    }
}
