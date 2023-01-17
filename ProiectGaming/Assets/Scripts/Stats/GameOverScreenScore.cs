using UnityEngine.UI;
using UnityEngine;

public class GameOverScreenScore : MonoBehaviour
{
    Text textScor;

    public void Start()
    {
        textScor = GetComponent<Text>();
        textScor.text = string.Format("Your score was: {0}", Score.Value);   
        Score.ResetScore();
    }
}
