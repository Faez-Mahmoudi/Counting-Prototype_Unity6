using UnityEngine;

public class BasketSensor : MonoBehaviour
{
    [SerializeField] private bool ID;
    [SerializeField] GameObject goalSensor;
    private BoxCollider boxCol;
    
    private void Start()
    {
        boxCol = goalSensor.GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball") && MainManager.Instance.isGameActive)
        {
            boxCol.enabled = ID;
        }
    }
}
