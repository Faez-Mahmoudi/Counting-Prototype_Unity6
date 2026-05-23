using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance{get; private set;}
    public int numberOfPlayer;
    public int orgGoals;
    public int orgMinutes;
    public bool isGameActive;

    public Color leftUiColor;
    public int leftUiColorNumber;
    public Color rightUiColor;
    public int rightUiColorNumber;

    public AudioSource my_audio;

    // Save our data
    [System.Serializable]
    class SaveData
    {
        public int n_player;
        public int org_goals;
        public int org_Min;
        public int l_color;
        public int r_color;
    }

    void Awake()
    {
       if (Instance != null)
       {
            Destroy(gameObject);
            return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject);
       my_audio = GetComponent<AudioSource>(); 
       isGameActive = false;
       LoadScore();
       my_audio.volume = 0.25f;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.n_player = numberOfPlayer;
        data.org_goals = orgGoals;
        data.org_Min = orgMinutes;
        data.l_color = leftUiColorNumber;
        data.r_color = rightUiColorNumber;

        string json  = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            numberOfPlayer = data.n_player;
            orgGoals = data.org_goals;
            orgMinutes = data.org_Min;
            leftUiColorNumber = data.l_color;
            rightUiColorNumber = data.r_color;
        }
        else
        {
            numberOfPlayer = 1;
            orgGoals = 7;
            orgMinutes = 3;
            leftUiColorNumber = 2;
            rightUiColorNumber = 4;
        }
    }
}
