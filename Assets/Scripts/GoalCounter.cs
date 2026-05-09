using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{
    [SerializeField] private int Count;
    [SerializeField] private int goalLimit;
    [SerializeField] private GameObject digitalScoreBoard;
    private DigitalNumber dgNumber;

    private UIHandler uiHandler;
    private AudioSource netAudio;
    [SerializeField] private AudioClip cheerSound;

    private void Start()
    {
        Count = 0;
        goalLimit = MainManager.Instance.orgGoals;
        uiHandler = GameObject.Find("CanvasWorldSpace").GetComponent<UIHandler>();
        dgNumber = digitalScoreBoard.GetComponent<DigitalNumber>();
        netAudio = GetComponent<AudioSource>();
        dgNumber.ShowNumber(0);
    }

    private void Update()
    {
        if(!MainManager.Instance.isGameActive)
        {
            dgNumber.ShowNumber(0);
            Count = 0;
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball") && MainManager.Instance.isGameActive)
        {
            Count += 1;
            dgNumber.ShowNumber(Count);
            netAudio.PlayOneShot(cheerSound, 0.7f);
            if (Count >= goalLimit)
            {
                uiHandler.GameIsOver();
                MainManager.Instance.isGameActive = false;
            }
        }
    }

    public void GoalLimit(int lim)
    {
        goalLimit = lim;
        Count = 0;
        dgNumber.ShowNumber(0);
        MainManager.Instance.orgGoals = goalLimit;
    }
}
