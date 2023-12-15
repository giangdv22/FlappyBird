using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip wing;
    [SerializeField] private AudioClip point;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Player.Instance.OnWing += Player_OnWing;
        Score.Instance.OnPoint += Score_OnScore;
        FlappyBirdGameManager.Instance.OnGameOver += FlappyBirdGameManager_OnGameOver;
    }

    private void FlappyBirdGameManager_OnGameOver(object sender, System.EventArgs e)
    {
        PlaySound(hit,Camera.main.gameObject.transform.position);
        Debug.Log("-");
    }

    private void Score_OnScore(object sender, System.EventArgs e)
    {
        PlaySound(point, Player.Instance.gameObject.transform.position);

    }

    private void Player_OnWing(object sender, System.EventArgs e)
    {
        PlaySound(wing, Player.Instance.gameObject.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
