using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class BallTail : MonoBehaviour
{
    private TrailRenderer trail;
    private bool swiping = false;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            swiping = true;
            UpdateComponents();
        }
        else if (collision.gameObject.GetComponent<Border>())
        {
            swiping = false;
            UpdateComponents();
        }
    }

    void UpdateComponents()
    {
        trail.enabled = swiping;
    }
}
