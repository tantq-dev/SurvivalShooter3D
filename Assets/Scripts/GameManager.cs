using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable playerHP;
    private bool _gameOver;
    public IntVariable EnemyKillCount;
    public IntVariable bestScore;
    [SerializeField] private GameObject gameOverPannel;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject pauseGameUI;
    [SerializeField] private TextMeshProUGUI enemyCount;
    
    void Start()
    {
        EnemyKillCount.Value = 0;
        enemyCount.text = "0";
        gameOverPannel.SetActive(false);
        ingameUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        _gameOver = playerHP.Value <= 0;
        if (_gameOver)
        {
            StartCoroutine(WaitToPopup(2f));
        }

        enemyCount.text = EnemyKillCount.Value.ToString();
        if (bestScore.Value < EnemyKillCount.Value)
        {
            bestScore.Value = EnemyKillCount.Value;
        }
    }

    IEnumerator WaitToPopup(float time)
    {
        yield return new WaitForSeconds(time);
        ingameUI.SetActive(false);
        gameOverPannel.SetActive(true);
    }

    public void PauseGamePress()
    {
        pauseGameUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinuePress()
    {
        pauseGameUI.SetActive(false);
        Time.timeScale = 1;
    }
    
}
