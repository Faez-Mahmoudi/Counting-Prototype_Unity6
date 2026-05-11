using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ChangeOneTwoPlayer : MonoBehaviour
{
    private Button button;
    private SinglePlayer onePlayer;
    private PlayerController twoPlayer;
    [SerializeField] private int ID;

    private AudioSource buttonAudio;
    [SerializeField] AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       onePlayer = GameObject.Find("Player1").GetComponent<SinglePlayer>();
       twoPlayer = GameObject.Find("Player1").GetComponent<PlayerController>();
       button.onClick.AddListener(SetEnabel);
       buttonAudio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (MainManager.Instance.numberOfPlayer == ID)
            button.enabled = false;
        else
            button.enabled = true;

        if (MainManager.Instance.numberOfPlayer == 1)
        {
            onePlayer.enabled = true;
            twoPlayer.enabled = false; 
        }
        else if (MainManager.Instance.numberOfPlayer == 2)
        {
            onePlayer.enabled = false;
            twoPlayer.enabled = true;
        }
    }

    void SetEnabel()
    {
        MainManager.Instance.numberOfPlayer = ID;
        buttonAudio.PlayOneShot(clickSound, 1.0f);
    }
}
