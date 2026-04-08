using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    [SerializeField] private int Count = 0;
    //[SerializeField] private int ID = 0;

    // UI
    [SerializeField] private TextMeshProUGUI pointText;


    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Count += 1;
            pointText.text = "Points: " + Count;
        }
    }
}
