using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Start()
    {
        List<HighScoreEntry> leaderboard = ScoreManager.Instance.LoadLeaderboard();
        leaderboard = leaderboard.OrderByDescending(entry => entry.Score).ToList();
        
        entryTemplate = transform.Find("HighscoreTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 80f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, transform);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            
            entryTransform.Find("ScoreTemplate").GetComponent<TextMeshProUGUI>().text =
                leaderboard[i].Score.ToString();
            entryTransform.Find("PositionTemplate").GetComponent<TextMeshProUGUI>().text =
                (i + 1).ToString();
            entryTransform.Find("DateTemplate").GetComponent<TextMeshProUGUI>().text =
                leaderboard[i].Date;
        }
    }

    void Awake()
    {
        
    }
    
}
