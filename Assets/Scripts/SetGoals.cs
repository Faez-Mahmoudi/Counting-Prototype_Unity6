using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class SetGoals : MonoBehaviour
{
    private Button button;
    private Image image;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private int goals;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(SetGoalLimit); 
        buttonAudio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (!MainManager.Instance.isGameActive)
        {
            if (MainManager.Instance.orgGoals == goals)
                button.enabled = false;
            else
                button.enabled = true;

            buttonText.color = MainManager.Instance.rightUiColor;
            image.color = MainManager.Instance.rightUiColor;
        }
    }

    void SetGoalLimit()
    {
        foreach (var g in FindObjectsByType<GoalCounter>(FindObjectsSortMode.None))
            g.GoalLimit(goals);
        
        buttonAudio.PlayOneShot(clickSound, 1.0f);
    }
}
