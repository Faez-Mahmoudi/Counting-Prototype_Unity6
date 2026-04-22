using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    [SerializeField] private int Count = 0;
    [SerializeField] private int goalLimit;
    [SerializeField] private GameObject digitalScoreBoard;
    private DigitalNumber dgNumber;
    //[SerializeField] private int ID = 0;


    private void Start()
    {
        Count = 0;
        goalLimit = 7;
        dgNumber = digitalScoreBoard.GetComponent<DigitalNumber>();
        dgNumber.ShowNumber(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Count += 1;
            dgNumber.ShowNumber(Count);
        }
    }

    public void GoalLimit(int lim)
    {
        goalLimit = lim;
    }
}
