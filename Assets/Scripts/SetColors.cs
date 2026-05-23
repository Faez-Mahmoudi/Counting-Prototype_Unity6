using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SetColors : MonoBehaviour
{
    private ColorManager colorManager;

    private Button button;
    private Image img;
    [SerializeField] private int colorNumber;
    [SerializeField] private int ID;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        img = GetComponent<Image>();
        button.onClick.AddListener(SendColor); 
        buttonAudio = GetComponent<AudioSource>();
        colorManager = GameObject.Find("CanvasWorldSpace").GetComponent<ColorManager>();
    }

    void Update()
    {
        if (!MainManager.Instance.isGameActive)
        {
            if ((ID == 1 && MainManager.Instance.leftUiColorNumber == colorNumber) || (ID == 2 && MainManager.Instance.rightUiColorNumber == colorNumber))
            {
                img.enabled = false;
                button.enabled = false;
            }
            else
            {
                img.enabled = true;    
                button.enabled = true;
            }   
        }
    }

    void SendColor()
    {
        colorManager.SetColor(ID, colorNumber);
        buttonAudio.PlayOneShot(clickSound, 1.0f);
    }
}
