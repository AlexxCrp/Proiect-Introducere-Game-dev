using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int Value = 0;
    public static Text scoreText;

    public static void IncrementScore()
    {
        Value++;
        ScoreDisplay();
    }
    public static void ResetScore()
    {
        Value = 0;
    }

    public static void ScoreDisplay()
    {
        scoreText.text = Value.ToString();
    }

    public void Start()
    {
        scoreText = GetComponent<Text>();
        ScoreDisplay();
    }
}
