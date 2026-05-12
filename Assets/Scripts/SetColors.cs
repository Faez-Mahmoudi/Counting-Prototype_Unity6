using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SetColors : MonoBehaviour
{
    private ColorManager colorManager;

    private Button button;
    [SerializeField] private int colorNumber;
    [SerializeField] private int ID;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendColor); 
        buttonAudio = GetComponent<AudioSource>();
        colorManager = GameObject.Find("CanvasWorldSpace").GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendColor()
    {
        colorManager.SetColor(ID, colorNumber);
    }
}
