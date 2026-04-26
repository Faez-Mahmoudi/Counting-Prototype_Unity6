using UnityEngine;
using UnityEngine.UI;

public class ChangeOneTwoPlayer : MonoBehaviour
{
    private Button button;
    private SinglePlayer onePlayer;
    private PlayerController twoPlayer;
    [SerializeField] private bool isSinglePlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       onePlayer = GameObject.Find("Player1").GetComponent<SinglePlayer>();
       twoPlayer = GameObject.Find("Player1").GetComponent<PlayerController>();
       button.onClick.AddListener(SetEnabel); 
    }

    void SetEnabel()
    {
        onePlayer.enabled = isSinglePlay;
        twoPlayer.enabled = !isSinglePlay;
    }
}
