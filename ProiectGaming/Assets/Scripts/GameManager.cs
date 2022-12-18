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
        Playing
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

        // Just some driver code to test
        // if (Input.GetKey(KeyCode.C))
        // {
        //     ScoreManager.Instance.SaveToLeaderboard("asd");
        // }
        // if (Input.GetKey(KeyCode.X))
        // {
        //     ScoreManager.Instance.LoadLeaderboard();
        // }
    }

    // To start a random scene, pass a random number to LoadScene
    private void StartGame()
    {
        gameState = GameState.Playing;
        SceneManager.LoadSceneAsync("SampleScene");
    }
}