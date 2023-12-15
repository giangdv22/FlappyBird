using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private List<NumberSO> numberSOList;
    [SerializeField] private Transform numberTemplate;

    private void Awake()
    {
        numberTemplate.gameObject.SetActive(false);
    }
    private void Update()
    {
        UpdateScoreVisual();
    }

    private void UpdateScoreVisual()
    {
        foreach(Transform child in gameObject.transform)
        {
            if (child == numberTemplate) continue;
            Destroy(child.gameObject);
        }
        string scoreString = Score.Instance.GetScore().ToString();
        for (int i = 0; i < scoreString.Length; i++)
        {
            char number = scoreString[i];
            foreach (NumberSO expectedNumber in numberSOList)
            {
                if (number == expectedNumber.number)
                {
                    Transform numberTransform = Instantiate(numberTemplate, gameObject.transform);
                    numberTransform.gameObject.SetActive(true);
                    numberTransform.localPosition = new Vector3(i * 100 - (scoreString.Length - 1) * 50, 0, 0);
                    numberTransform.GetComponent<Image>().sprite = expectedNumber.numberSprite;
                    break;
                }
            }
        }
    }
}
