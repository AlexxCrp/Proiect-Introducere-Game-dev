using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    // To start a random scene, pass a random number to LoadScene
    private void StartGame()
    {
        gameState = GameState.Playing;
        SceneManager.LoadSceneAsync("SampleScene");
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
    private void OpenLeaderboard()
    {
        gameState = GameState.Leaderboard;
        SceneManager.LoadSceneAsync("LeaderboardScene");
    }
}