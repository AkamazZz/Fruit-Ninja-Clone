using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score elements")]
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    [Header("Game over elements")]
    [SerializeField] private GameObject _gameOverPanel;

    public void IncreaseScore(int addedPoints)
    {
        _score += addedPoints;
        _scoreText.text = _score.ToString();
    }
    public void OnBombHit()
    {
        Debug.Log("Bomb hit");
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime =  0.002f;
    }
    public void RespawnScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
