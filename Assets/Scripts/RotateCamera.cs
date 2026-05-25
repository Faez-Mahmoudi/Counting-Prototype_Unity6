using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float ballPositionZ = ball.transform.position.z / 240.0f;
        gameObject.transform.rotation = new Quaternion(0, ballPositionZ, 0, 1);
    }
}
