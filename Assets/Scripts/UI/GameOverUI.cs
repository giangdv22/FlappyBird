using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button PlayButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private void Start()
    {
        FlappyBirdGameManager.Instance.OnGameOver += FlappyBirdGameManager_OnGameOver;
        Hide();
    }

    private void FlappyBirdGameManager_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
