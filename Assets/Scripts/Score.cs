using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event EventHandler OnPoint;
    public static Score Instance { get; private set; }

    private int score;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore()
    {
        score++;
        OnPoint?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore()
    {
        return score;
    }

}
