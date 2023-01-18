using UnityEngine.UI;
using UnityEngine;

public class GameOverScreenScore : MonoBehaviour
{
    Text textScor;

    public void Start()
    {
        textScor = GetComponent<Text>();
        textScor.text = "Your score was: " + Score.Value;
        ScoreManager.Instance.SaveToLeaderboard();
        Score.ResetScore();
    }
}
