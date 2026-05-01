using UnityEngine;
using UnityEngine.UI;

public class SetMinutes : MonoBehaviour
{
    private Button button;
    private CountDownClock clock;

    [SerializeField] private int minutes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       clock = GameObject.Find("DigitalClock").GetComponent<CountDownClock>();
       button.onClick.AddListener(SetTime); 
    }

    void Update()
    {
        if (MainManager.Instance.orgMinutes == minutes)
            button.enabled = false;
        else
            button.enabled = true;
    }

    void SetTime()
    {
        clock.StartTime(minutes);
    }
}
