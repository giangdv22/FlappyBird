// Ignore Spelling: Flappy

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGameManager : MonoBehaviour
{
    public event EventHandler OnGameOver;
    public static FlappyBirdGameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

}
