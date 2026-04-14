using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    [SerializeField] private int Count = 0;
    [SerializeField] private GameObject digitalScoreBoard;
    private DigitalNumber dgNumber;
    //[SerializeField] private int ID = 0;

    // UI
    [SerializeField] private TextMeshProUGUI pointText;


    private void Start()
    {
        Count = 0;
        dgNumber = digitalScoreBoard.GetComponent<DigitalNumber>();
        dgNumber.ShowNumber(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Count += 1;
            pointText.text = "Points: " + Count;
            dgNumber.ShowNumber(Count);
        }
    }
}
