using UnityEngine;
using UnityEngine.UI;

public class SetGoals : MonoBehaviour
{
    private Button button;
    //private GoalCounter goalCounter;

    [SerializeField] private int goals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       //goalCounter = GameObject.Find("DigitalClock").GetComponent<CountDownClock>();
       button.onClick.AddListener(SetGoalLimit); 
    }

    void SetGoalLimit()
    {
        foreach (var g in FindObjectsByType<GoalCounter>(FindObjectsSortMode.None))
            g.GoalLimit(goals);
    }
}
