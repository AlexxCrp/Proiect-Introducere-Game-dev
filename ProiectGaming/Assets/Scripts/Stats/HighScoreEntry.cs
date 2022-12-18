using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreEntry
{
    public String Name;

    public int Score;

    public HighScoreEntry(string name, int score)
    {
        Name = name;
        Score = score;
    }
}