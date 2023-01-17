using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Playing,
        GameOver,
        Leaderboard
    }

    public static GameManager Instance { get; private set; }

    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (gameState == GameState.Menu && Input.GetKey(KeyCode.Return))
        {
            StartGame();
        }

        if(gameState == GameState.GameOver && Input.GetKey(KeyCode.Escape))
        {
            ScoreManager.Instance.SaveToLeaderboard();
            OpenMenu();
        }
        
        if(gameState == GameState.Leaderboard && Input.GetKey(KeyCode.Escape))
        {
            OpenMenu();
        }
        
        if(gameState == GameState.Menu && Input.GetKey(KeyCode.L))
        {
            OpenLeaderboard();
        }

        if (gameState == GameState.Playing && Input.GetKey(KeyCode.P)) 
        {
            //LoadRandomScene() - Functie wip intai trebuie facute niste levels
        }
    }

    // To start a random scene, pass a random number to LoadScene
    private void StartGame()
    {
        gameState = GameState.Playing;
        SceneManager.LoadSceneAsync("Level1");
    }
    private void OpenMenu()
    {
        gameState = GameState.Menu;
        SceneManager.LoadSceneAsync("MenuScene");
    }

    public void OpenGameOver()
    {
        gameState = GameState.GameOver;
        SceneManager.LoadSceneAsync("GameOverScene");
    }
    public void OpenNextLevel(string level)
    {
        SceneManager.LoadSceneAsync(level);
    }
    private void OpenLeaderboard()
    {
        gameState = GameState.Leaderboard;
        SceneManager.LoadSceneAsync("LeaderboardScene");
    }

}