using System;
using System.Collections;
using System.Collections.Generic;
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
        if (File.Exists(LeaderboardSaveFilePath))
        {
            LoadLeaderboard();
        }
        else
        {
            Leaderboard = new List<HighScoreEntry>();
        }
    }

    public void SaveToLeaderboard(String playerName)
    {
        HighScoreEntry newHighScore = new HighScoreEntry(playerName, Score.Value);
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