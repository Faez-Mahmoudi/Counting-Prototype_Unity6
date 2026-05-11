using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SetMinutes : MonoBehaviour
{
    private Button button;
    private CountDownClock clock;

    [SerializeField] private int minutes;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       clock = GameObject.Find("DigitalClock").GetComponent<CountDownClock>();
       button.onClick.AddListener(SetTime);
       buttonAudio = GetComponent<AudioSource>(); 
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
        buttonAudio.PlayOneShot(clickSound, 1.0f);
    }
}
