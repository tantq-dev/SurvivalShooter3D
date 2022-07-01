using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private IntVariable enemyKillCount;
    [SerializeField] private IntVariable bestScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + enemyKillCount.Value.ToString();
        bestScoreText.text = "BEST SCORE: " + bestScore.Value.ToString();
    }
}
