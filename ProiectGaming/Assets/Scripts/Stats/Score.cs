using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Value = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Value.ToString();
        
    }
}
