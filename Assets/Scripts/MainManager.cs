using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance{get; private set;}
    public float musicVolume;
    public int numberOfPlayer;
    public int orgGoals;
    public int orgMinutes;
    public bool isGameActive;

    public AudioSource my_audio;

    // Save our data
    [System.Serializable]
    class SaveData
    {
        public int n_player;
        public float m_volume;
        public int org_goals;
        public int org_Min;
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
       my_audio.volume = musicVolume;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.n_player = numberOfPlayer;
        data.m_volume = musicVolume;
        data.org_goals = orgGoals;
        data.org_Min = orgMinutes;

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
            musicVolume = data.m_volume;
            orgGoals = data.org_goals;
            orgMinutes = data.org_Min;
        }
        else
        {
            numberOfPlayer = 1;
            musicVolume = 0.5f;
            orgGoals = 7;
            orgMinutes = 3;
        }
    }
}
