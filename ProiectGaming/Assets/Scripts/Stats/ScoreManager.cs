using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public String LeaderboardSaveFilePath => Application.persistentDataPath + "/Leaderboard.json";
    [SerializeField] public List<HighScoreEntry> Leaderboard;

    private void Start()
    {
        // if (File.Exists(LeaderboardSaveFilePath))
        // {
        //     LoadLeaderboard();
        //     Debug.Log("Laoded");
        // }
        // else
        // {
        //     Leaderboard = new List<HighScoreEntry>();
        // }
    }

    public void SaveToLeaderboard()
    {
        if (File.Exists(LeaderboardSaveFilePath))
        {
            Leaderboard = LoadLeaderboard();
        }
        else
        {
            Leaderboard = new List<HighScoreEntry>();
        }
        
        HighScoreEntry newHighScore = new HighScoreEntry(DateTime.Now.ToString(CultureInfo.CurrentCulture), Score.Value);
        Leaderboard.Add(newHighScore);

        var json = JsonHelper.ToJson(Leaderboard.ToArray());
        File.WriteAllText(LeaderboardSaveFilePath, json);
    }

    public List<HighScoreEntry> LoadLeaderboard()
    {
        var json = File.ReadAllText(LeaderboardSaveFilePath);
        var highScores = JsonHelper.FromJson<HighScoreEntry>(json);
        Leaderboard = new List<HighScoreEntry>(highScores);
        return Leaderboard;
    }
}