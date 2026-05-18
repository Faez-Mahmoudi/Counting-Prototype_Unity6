using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class SetMinutes : MonoBehaviour
{
    private Button button;
    private Image image;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private int minutes;

    private CountDownClock clock;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       image = GetComponent<Image>();
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

        buttonText.color = MainManager.Instance.leftUiColor;
        image.color = MainManager.Instance.leftUiColor;
    }

    void SetTime()
    {
        clock.StartTime(minutes);
        buttonAudio.PlayOneShot(clickSound, 1.0f);
    }
}
