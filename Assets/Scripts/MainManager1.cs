using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    public string playerName;
    public int score;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveScore()
    {
        highScore = score;
        highScoreName = playerName;
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.playerName;
            highScore = data.score;
        }
    }
}
