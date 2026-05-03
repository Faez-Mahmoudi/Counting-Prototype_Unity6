using UnityEngine;
using UnityEngine.UI;

public class ChangeOneTwoPlayer : MonoBehaviour
{
    private Button button;
    private SinglePlayer onePlayer;
    private PlayerController twoPlayer;
    [SerializeField] private bool isSinglePlay;
    [SerializeField] private int ID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       button = GetComponent<Button>();
       onePlayer = GameObject.Find("Player1").GetComponent<SinglePlayer>();
       twoPlayer = GameObject.Find("Player1").GetComponent<PlayerController>();
       button.onClick.AddListener(SetEnabel); 
    }

    void Update()
    {
        if (MainManager.Instance.numberOfPlayer == ID)
            button.enabled = false;
        else
            button.enabled = true;
    }

    void SetEnabel()
    {
        MainManager.Instance.numberOfPlayer = ID;
        onePlayer.enabled = isSinglePlay;
        twoPlayer.enabled = !isSinglePlay;
    }
}
