using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -4)
            Destroy(gameObject);
    }
}
