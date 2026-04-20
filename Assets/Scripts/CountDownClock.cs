using UnityEngine;

public class CountDownClock : MonoBehaviour
{
    [SerializeField] private GameObject secondOne;
    [SerializeField] private GameObject secondTwo;
    [SerializeField] private GameObject minutes;
    private DigitalNumber dgSecond1;
    private DigitalNumber dgSecond2;
    private DigitalNumber dgMinutes;

    private float startDelay = 1;
    private float repeatRate = 1;

    [SerializeField] private int m_Sec1 = 0;
    [SerializeField] private int m_Sec2 = 0;
    [SerializeField] private int m_Min;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dgSecond1 = secondOne.GetComponent<DigitalNumber>();
        dgSecond2 = secondTwo.GetComponent<DigitalNumber>();
        dgMinutes = minutes.GetComponent<DigitalNumber>();

        m_Min = 3;

        ClockToShow(m_Min, m_Sec2, m_Sec1);
        InvokeRepeating("CowntDown", startDelay, repeatRate);
    }

    public void StartTime(int m)
    {
        m_Min = m;
        ClockToShow(m_Min, m_Sec2, m_Sec1);
    }

    private void CowntDown()
    {
        if (m_Sec2 == 0 && m_Sec1 == 0 && m_Min != 0)
        {
            m_Min--;
            m_Sec2 = 5;
            m_Sec1 = 9;
        }
        else if (m_Sec1 == 0 && m_Sec2 != 0)
        {
            m_Sec1 = 9;
            m_Sec2--;
        }
        else if (m_Sec1 != 0)
            m_Sec1--;
                        
        ClockToShow(m_Min, m_Sec2, m_Sec1);
    }

    private void ClockToShow(int min, int sec2, int sec1)
    {
        dgSecond1.ShowNumber(sec1);
        dgSecond2.ShowNumber(sec2);
        dgMinutes.ShowNumber(min);
    }
}
