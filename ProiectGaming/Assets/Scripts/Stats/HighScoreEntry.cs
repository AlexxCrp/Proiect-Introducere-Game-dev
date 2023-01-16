using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreEntry
{
    public String Date;

    public int Score;
    
    public HighScoreEntry(String date, int score)
    {
        Date = date;
        Score = score;
    }
}