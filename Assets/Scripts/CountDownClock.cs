using UnityEngine;

public class CountDownClock : MonoBehaviour
{
    [SerializeField] private GameObject secondOne;
    [SerializeField] private GameObject secondTwo;
    [SerializeField] private GameObject minutes;
    private DigitalNumber dgSecond1;
    private DigitalNumber dgSecond2;
    private DigitalNumber dgMinutes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dgSecond1 = secondOne.GetComponent<DigitalNumber>();
        dgSecond2 = secondTwo.GetComponent<DigitalNumber>();
        dgMinutes = minutes.GetComponent<DigitalNumber>();

        ClockToShow(3, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClockToShow(int min, int sec2, int sec1)
    {
        dgSecond1.ShowNumber(sec1);
        dgSecond2.ShowNumber(sec2);
        dgMinutes.ShowNumber(min);
    }
}
