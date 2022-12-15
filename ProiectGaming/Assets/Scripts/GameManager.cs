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
    }

    // To start a random scene, pass a random number to LoadScene
    private void StartGame()
    {
        gameState = GameState.Playing;
        SceneManager.LoadSceneAsync("SampleScene");
    }
}