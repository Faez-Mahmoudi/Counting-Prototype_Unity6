using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance{get; private set;}
    public float musicVolume;
    public bool isGameActive;

    public AudioSource my_audio;

    // Save our data
    [System.Serializable]
    class SaveData
    {
        public float m_volume;
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
       isGameActive = true;
       LoadScore();
       my_audio.volume = musicVolume;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.m_volume = musicVolume;

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

            musicVolume = data.m_volume;
        }
        else
        {
            musicVolume = 1.0f;
        }
    }
}
