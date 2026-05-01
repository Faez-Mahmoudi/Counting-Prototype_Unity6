using UnityEngine;
using UnityEngine.UI;

public class SetGoals : MonoBehaviour
{
    private Button button;
    [SerializeField] private int goals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       button.onClick.AddListener(SetGoalLimit); 
    }

    void Update()
    {
        if (MainManager.Instance.orgGoals == goals)
            button.enabled = false;
        else
            button.enabled = true;
    }

    void SetGoalLimit()
    {
        foreach (var g in FindObjectsByType<GoalCounter>(FindObjectsSortMode.None))
            g.GoalLimit(goals);
    }
}
