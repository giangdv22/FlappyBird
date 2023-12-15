using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private static int mScore;
    private static float mSpeed = 2.0f;
    public static void ResetScore()
    {
        mScore = 0;
    }
    private void Update()
    {
        transform.position += Vector3.left * mSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.Instance.UpdateScore();
        }
    }

    public static float GetSpeed()
    {
        return mSpeed;
    }

    public static void SetSpeed(float speed)
    {
        mSpeed = speed;
    }
}
