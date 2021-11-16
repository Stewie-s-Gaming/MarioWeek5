using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] int scorePerCoin = 1;

    private TextMeshPro scoreText;
    private int score = 0;

    void Start()
    {
        scoreText = transform.Find("Score").GetComponent<TextMeshPro>();
        SetScore(0);
    }

    private void SetScore(int s)
    {
        score = s;
        scoreText.text = score.ToString();
    }

    public void CollectCoin()
    {
        SetScore(score + scorePerCoin);
    }
}
